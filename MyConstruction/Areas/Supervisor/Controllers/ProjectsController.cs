using System.Linq;
using System.Threading.Tasks;
using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using MyConstruction.Models;
using MyConstruction.Models.ViewModels;
using OctaLib.Heleprs;
using OctaLib.Plugins.MyConstruction.Common.Enum;
using OctaLib.Plugins.MyConstruction.Data;
using OctaLib.Plugins.MyConstruction.Domain;
using OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas;

namespace MyConstruction.Areas.Supervisor.Controllers
{
	[Area("/Supervisor")]
	[AuthorizeUserArea(AccountUserArea.Code)]
	public class ProjectsController : Controller
    {

		private readonly IAdvancedContentRepository _contentRepository;
        private readonly MyConstructionDbContext _context;
        private readonly ProjectInfoProvider _projectInfo;
        private readonly WorkCategoryInfoProvider _workCategoryInfo;
        private readonly ContractorInfoProvider _contractorInfo;
        private readonly StockInfoProvider _stockInfo;
        private readonly ProjectTaskInfoProvider _projectTaskInfo;
        private readonly TeamInfoProvider _teamInfo;
        private readonly MaterialInfoProvider _materialInfo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly TasksInfoProvider _tasksInfo;
        private readonly WorkTaskInfoProvider _workTaskInfo;
        private readonly QualityInfoProvider _qualityInfo;

        public ProjectsController(
			IAdvancedContentRepository contentRepository,
            MyConstructionDbContext context,
            ProjectInfoProvider projectInfo,
            WorkCategoryInfoProvider workCategoryInfo,
            ContractorInfoProvider contractorInfo,
            StockInfoProvider stockInfo,
            ProjectTaskInfoProvider projectTaskInfo,
            TeamInfoProvider teamInfo,
            MaterialInfoProvider materialInfo,
            TasksInfoProvider taskInfo,
            WorkTaskInfoProvider workTaskInfo,
            QualityInfoProvider qualityInfo,
            IWebHostEnvironment hostEnvironment)
		{
			_contentRepository = contentRepository;
            _context = context;
            _projectInfo = projectInfo;
            _workCategoryInfo = workCategoryInfo;
            _contractorInfo = contractorInfo;
            _stockInfo = stockInfo;
            _projectTaskInfo = projectTaskInfo;
            _teamInfo = teamInfo;
            _materialInfo = materialInfo;
            _tasksInfo = taskInfo;
            _workTaskInfo = workTaskInfo;
            _qualityInfo = qualityInfo;
            _hostingEnvironment = hostEnvironment;
        }

		[Route("/Supervisor/Projects")]
        public async Task<IActionResult> IndexAsync()
        {

			var member = await _contentRepository
			.Users()
			.Current()
			.Get()
			.AsMicroSummary()
			.ExecuteAsync();

			return View(member);

        }


        [Route("/Supervisor/Projects/SiteUpdate/{id}")]
        [HttpGet]
        public IActionResult SiteUpdate(int id, long datekey = 0)
        {

			SiteUpdateVM vm = new SiteUpdateVM();

			if (datekey.ToString().Length != 8)
			{
				DateTime date = DateTime.Today;
				datekey = date.ToDateKey();
			}

			//have to remove the datekey parameter for Supervisor, Only add for Admin
			var workCategories = _workCategoryInfo.GetInfos().Select(x => x.Id).ToList();
            bool teamshow = false;
            bool materialshow = false;
            foreach(var workCategory in workCategories)
            {
                var contractors = _contractorInfo.GetInfos().Where(x => x.WorkCategoryIds.Contains(workCategory)).Select(e => e.Id).ToList();
                
                foreach(var contractor in contractors)
                {
                    var check = _teamInfo.GetTeam(id, workCategory, contractor, datekey);

                    if (check.ProjectId == 0 && check.WorkCategoryId == 0 && check.ContractorId == 0 && check.DateKey == 0)
                    {
                        teamshow = true;
                        goto teamloop;
                    }

				}
                
                
            }
        teamloop:

            vm.TeamShow = teamshow;

            var stocks = _stockInfo.GetInfos().Select(x => x.Id).ToList();

            foreach(var stock in stocks)
            {

                var check = _materialInfo.GetMaterial(id, stock, datekey);

                if(check.ProjectId == 0 && check.StockId == 0 && check.Datekey == 0)
                {
                    materialshow = true;
                    break;
                }

            }

            vm.MaterialShow = materialshow;
            

            var teams = _teamInfo.GetAllTeams(id, datekey);
            var materials = _materialInfo.GetAllMaterials(id, datekey);
            var tasks = _qualityInfo.GetAllTasks(id, datekey);
            var teamList = new List<TeamDetail>();
            var materialList = new List<MaterialDetail>();
            var taskList = new List<ProjectTaskDetail>();
            foreach (var team in teams)
            {
                TeamDetail dt = new TeamDetail();
                dt.ProjectId = team.ProjectId;
                dt.WorkCategoryId = team.WorkCategoryId;
                dt.ContractorId = team.ContractorId;
                dt.ProjectName = _projectInfo.GetInfoById(team.ProjectId).Name;
                dt.WorkCategory = _workCategoryInfo.GetInfoById(team.WorkCategoryId).Name;
                dt.ContractorName = _contractorInfo.GetInfoById(team.ContractorId).Name;
                dt.NoOfMen = team.NoOfMen;
                dt.ImageUrl = team.ImageUrl;

                teamList.Add(dt);
            }


            foreach (var material in materials)
            {
                MaterialDetail mt = new MaterialDetail();
                mt.ProjectId = material.ProjectId;
                mt.StockId = material.StockId;
                mt.StockName = _stockInfo.GetInfoById(material.StockId).Name;
                mt.NewStock = material.NewStock;
                mt.UsedStock = material.UsedStock;

                materialList.Add(mt);
            }


            foreach (var task in tasks)
            {
                ProjectTaskDetail ptt = new ProjectTaskDetail();
                ptt.TaskId = task.TaskId;
                ptt.ProjectId = task.ProjectId;
				ptt.TaskName = _tasksInfo.GetInfoById(task.TaskId).Name;
                ptt.Description = task.TaskDescription;
                ptt.Status = task.TaskStatus;

                taskList.Add(ptt);
            }



            vm.projectId = id;
            vm.Teams = teamList;
            vm.Materials = materialList;
            vm.ProjectTasks = taskList;


            return View(vm);

        }


        [HttpGet("/Supervisor/Projects/SiteUpdate/SiteTeamUpdate/{id}")]
        public IActionResult Team(int id)
        {

			TeamVM vm = new TeamVM();
			var categories = _workCategoryInfo.GetWorkCategories();
			var OptionList = new List<SelectListItem>();

			foreach (var category in categories)
			{

                List<int> contractorsList = _teamInfo.GetTeams_ByProjectID_ByWorkCategoryId(id, category.Id, DateTime.Today.ToDateKey()).Select(x => x.ContractorId).ToList();
                List<int> contractors = _contractorInfo.GetInfos().Where(x => x.WorkCategoryIds.Contains(category.Id)).Select(e => e.Id).ToList();

                contractorsList.Sort();
                contractors.Sort();

                bool check = contractorsList.SequenceEqual(contractors);


				if (!check)
                {
					OptionList.Add(new SelectListItem
					{
						Text = category.Name,
						Value = category.Id.ToString()
					});
				}

				
			}

			vm.WorkCategories = OptionList;
			vm.Team.ProjectId = id;

            return PartialView("_TeamModelPartial", vm);
		}


		[HttpPost("/Supervisor/Projects/SiteUpdate/SiteTeamUpdate")]
		public IActionResult Team(TeamVM vm, IFormFile? file)
		{
			DateTime date = DateTime.Today;
            long dateKey = date.ToDateKey();


			if (ModelState.IsValid)
			{

				string fileName = "";
				if (file != null)
				{
					string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "TeamImages");
					fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
					string filePath = Path.Combine(uploadDir, fileName);
					using (var filestream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(filestream);
					}
					vm.Team.ImageUrl = @"\TeamImages\" + fileName;
				}

				var check = _teamInfo.TeamAdd(vm.Team.ProjectId, vm.Team.WorkCategoryId, vm.Team.ContractorId, vm.Team.NoOfMen, vm.Team.ImageUrl, dateKey);

                if (check)
                {
                    return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Team.ProjectId);
                }
                
			}

            return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Team.ProjectId);

        }


        [HttpGet("/Supervisor/Team/Edit")]
        public IActionResult TeamEdit(int projectId, int workCategoryId, int contractorId)
        {

			DateTime date = DateTime.Today;
			long datekey = date.ToDateKey();

			TeamVM vm = new TeamVM();
			vm.Team = _teamInfo.GetTeam(projectId, workCategoryId, contractorId, datekey);

            vm.TeamDetail.ProjectName = _projectInfo.GetInfoById(projectId).Name;
			vm.TeamDetail.WorkCategory = _workCategoryInfo.GetInfoById(workCategoryId).Name;
			vm.TeamDetail.ContractorName = _contractorInfo.GetInfoById(contractorId).Name;

            return PartialView("_TeamEdit", vm);

		}


        [HttpPost("/Supervisor/Team/Edit")]
        public IActionResult TeamEdit(TeamVM vm, IFormFile? file)
        {

            if (ModelState.IsValid)
            {

                DateTime date = DateTime.Today;
                long datekey = date.ToDateKey();


				string fileName = "";
				if (file != null)
				{

					if (vm.Team.ImageUrl != null)
					{
						var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, vm.Team.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}


					string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "TeamImages");
					fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
					string filePath = Path.Combine(uploadDir, fileName);
					using (var filestream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(filestream);
					}
					vm.Team.ImageUrl = @"\TeamImages\" + fileName;
				}



				var check = _teamInfo.TeamEdit(vm.Team.ProjectId, vm.Team.WorkCategoryId, vm.Team.ContractorId, vm.Team.NoOfMen, vm.Team.DateKey);

                if (check)
                {
					return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Team.ProjectId);
				}
                else
                {
					return PartialView("_TeamEdit", vm);
				}

			}

			return PartialView("_TeamEdit", vm);
		}



        [HttpGet("/Supervisor/Team/Delete")]
        public IActionResult DeleteTeam(int projectId, int workCategoryId, int contractorId)
        {

            DateTime date = DateTime.Today;
            long datekey = date.ToDateKey();

            TeamVM vm = new TeamVM();
            vm.Team = _teamInfo.GetTeam(projectId, workCategoryId, contractorId, datekey);
            vm.TeamDetail.ProjectName = _projectInfo.GetInfoById(projectId).Name;
            vm.TeamDetail.WorkCategory = _workCategoryInfo.GetInfoById(workCategoryId).Name;
            vm.TeamDetail.ContractorName = _contractorInfo.GetInfoById(contractorId).Name;

            return PartialView("_TeamDelete", vm);

		}


		[HttpPost("/Supervisor/Team/Delete")]
        public IActionResult DeleteTeam(TeamVM vm)
        {

			DateTime date = DateTime.Today;
			long datekey = date.ToDateKey();

			if (vm.Team.ImageUrl != null)
			{
				var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, vm.Team.ImageUrl.TrimStart('\\'));
				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}
			}

			var check = _teamInfo.TeamDelete(vm.Team.ProjectId, vm.Team.WorkCategoryId, vm.Team.ContractorId, datekey);

			if (check)
			{
				return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Team.ProjectId);
			}

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Team.ProjectId);
		}


		[Route("/Supervisor/Projects/Team/GetContractors")]
		public IActionResult GetContractors(int projectId, int workCategoryId)
		{

            DateTime date = DateTime.Today;
            long datekey = date.ToDateKey();

            var contractorsList = _teamInfo.GetTeams_ByProjectID_ByWorkCategoryId(projectId, workCategoryId, datekey).Select(x => x.ContractorId).ToList();

			var contractors = _contractorInfo.GetContractors().Where(x => x.WorkCategoryIds.Contains(workCategoryId) && !contractorsList.Contains(x.Id));

			return Json(contractors);
		}



		[HttpGet("/Supervisor/Projects/SiteUpdate/SiteMaterialUpdate/{id}")]
        public IActionResult Material(int id)
        {

            DateTime date = DateTime.Today;
            long datekey = date.ToDateKey();

			MaterialVM vm = new MaterialVM();

			var list = new List<SelectListItem>();
			var stocks = _stockInfo.GetStocks();

			foreach (var stock in stocks)
			{

                var checkMaterial = _materialInfo.GetMaterial(id, stock.Id, datekey);

                if(checkMaterial.ProjectId == 0 && checkMaterial.StockId == 0 && checkMaterial.Datekey == 0)
                {

					list.Add(new SelectListItem
					{
						Text = stock.Name,
						Value = stock.Id.ToString()
					});

				}

				
			}



			vm.StocksList = list;
			vm.Material.ProjectId = id;

            return PartialView("_AddMaterial", vm);

		}


        [HttpPost("/Supervisor/Projects/SiteUpdate/SiteMaterialUpdate")]
        public IActionResult Material(MaterialVM vm)
        {
            if (ModelState.IsValid)
            {

                DateTime date = DateTime.Today;
                long datekey = date.ToDateKey();

                
                var check = _materialInfo.AddMaterial(vm.Material.ProjectId, vm.Material.StockId, vm.Material.NewStock, vm.Material.UsedStock, datekey);

                if (check)
                {
                    return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Material.ProjectId);
                }


            }

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Material.ProjectId);
		}


        [HttpGet("/Supervisor/Material/Edit")]
        public IActionResult MaterialEdit(int projectId, int stockId)
        {

            DateTime date = DateTime.Today;
            long datekey = date.ToDateKey();

            MaterialVM vm = new MaterialVM();

            vm.Material = _materialInfo.GetMaterial(projectId, stockId, datekey);
            vm.ProjectStockDetail.StockName = _stockInfo.GetInfoById(stockId).Name;

            return PartialView("_MaterialEdit", vm);


        }


        [HttpPost("/Supervisor/Material/Edit")]
        public IActionResult MaterialEdit(MaterialVM vm)
        {

            if (ModelState.IsValid)
            {

                DateTime date = DateTime.Today;
                long datekey = date.ToDateKey();

                var check = _materialInfo.MaterialEdit(vm.Material.ProjectId, vm.Material.StockId, vm.Material.NewStock, vm.Material.UsedStock, datekey);

                if (check)
                {
                    return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Material.ProjectId);
                }


            }

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Material.ProjectId);


		}

		[HttpGet("/Supervisor/Material/Delete")]
		public IActionResult MaterialDelete(int projectId, int stockId)
		{

			DateTime date = DateTime.Today;
			long datekey = date.ToDateKey();

			MaterialVM vm = new MaterialVM();

			vm.Material = _materialInfo.GetMaterial(projectId, stockId, datekey);
			vm.ProjectStockDetail.StockName = _stockInfo.GetInfoById(stockId).Name;

			return PartialView("_MaterialDelete", vm);


		}

        [HttpPost("/Supervisor/Material/Delete")]
        public IActionResult MaterialDelete(MaterialVM vm)
        {

            DateTime date = DateTime.Today;
            long datekey = date.ToDateKey();


            var check = _materialInfo.MaterialDelete(vm.Material.ProjectId, vm.Material.StockId, datekey);

            if (check)
            {
				return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Material.ProjectId);
			}

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Material.ProjectId);

		}


        [HttpGet("/Supervisor/Projects/SiteUpdate/SiteQualityUpdate/{projectId}")]
        public IActionResult AddQuality(int projectId)
        {

            QualityVM vm = new QualityVM();

            var workCategoryList = _workCategoryInfo.GetWorkCategories();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(var workCategory in workCategoryList)
            {
                list.Add(new SelectListItem
                {
                    Text = workCategory.Name,
                    Value = workCategory.Id.ToString()
                });
            }

            vm.WorkCategoryList = list;
            vm.Quality.ProjectId = projectId;
            vm.Quality.TaskStatus = "Pending";
            return PartialView("_AddQuality", vm);

        }

        [HttpPost("/Supervisor/Projects/SiteUpdate/SiteQualityUpdate")]
        public IActionResult AddQuality(QualityVM vm)
        {

            if (ModelState.IsValid)
            {

                DateTime date = DateTime.Today;
                long datekey = date.ToDateKey();
                vm.Quality.Datekey = datekey;
                var check = _qualityInfo.AddQuality(vm.Quality);

                if (check)
                {
					return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Quality.ProjectId);
				} 

            }

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.Quality.ProjectId);

		}


        [HttpGet("/Supervisor/Quality/Edit")]
        public IActionResult EditQuality(int projectId, int taskId)
        {

			long datekey = DateTime.Today.ToDateKey();

			ProjectTaskDetail vm = new ProjectTaskDetail();

			QualityInfo info = _qualityInfo.GetTask(projectId, taskId, datekey);

			vm.ProjectId = info.ProjectId;
			vm.TaskId = info.TaskId;
			vm.TaskName = _tasksInfo.GetInfoById(info.TaskId).Name;
			vm.Description = info.TaskDescription;
			vm.Status = info.TaskStatus;

            return PartialView("_QualityEdit", vm);

		}


        [HttpPost("/Supervisor/Quality/Edit")]
        public IActionResult EditQuality(ProjectTaskDetail vm)
        {

            if (ModelState.IsValid)
            {

                long datekey = DateTime.Today.ToDateKey();

                var check = _qualityInfo.EditQuality(vm.ProjectId, vm.TaskId, vm.Description, datekey);

                if (check)
                {
					return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.ProjectId);
				}

			}

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.ProjectId);

		}



        [HttpGet("/Supervisor/Quality/Delete")]
        public IActionResult DeleteQuality(int projectId, int taskId)
        {

			long datekey = DateTime.Today.ToDateKey();

			ProjectTaskDetail vm = new ProjectTaskDetail();

			QualityInfo info = _qualityInfo.GetTask(projectId, taskId, datekey);

			vm.ProjectId = info.ProjectId;
			vm.TaskId = info.TaskId;
			vm.TaskName = _tasksInfo.GetInfoById(info.TaskId).Name;
			vm.Description = info.TaskDescription;
			vm.Status = info.TaskStatus;

            return PartialView("_QualityDelete", vm);

		}


        [HttpPost("/Supervisor/Quality/Delete")]
        public IActionResult DeleteQuality(ProjectTaskDetail vm)
        {

            long datekey = DateTime.Today.ToDateKey();

            var check = _qualityInfo.DeleteQuality(vm.ProjectId, vm.TaskId, datekey);

            if (check)
            {
				return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.ProjectId);
			}

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.ProjectId);

		}



        [Route("/Supervisor/Quality/GetTasks")]
        public IActionResult GetTasks( int projectId, int workCategoryId)
        {
            var existing = _qualityInfo.GetAllTasks(projectId, DateTime.Today.ToDateKey()).Select(x => x.TaskId).ToList();
            var task = _workTaskInfo.GetWorkTasks().Where(x => x.WorkCategoryId == workCategoryId).FirstOrDefault();
            List<object> taskList = new List<object>();

            foreach(var tk in task.TaskIds)
            {

                if (!existing.Contains(tk))
                {
                    var taskname = _tasksInfo.GetTask().Where(x => x.Id == tk).FirstOrDefault();

                    taskList.Add(new
                    {
                        taskId = tk,
                        taskName = taskname.Name
                    });
                }
                
            }

            return Json(taskList);

        }




        [Route("/Supervisor/Quality/ReadMore")]
        public IActionResult QualityReadMore(int projectId, int taskId)
        {

            long datekey = DateTime.Today.ToDateKey();

            ProjectTaskDetail vm = new ProjectTaskDetail();

            QualityInfo info = _qualityInfo.GetTask(projectId, taskId, datekey);

            vm.ProjectId = info.ProjectId;
			vm.TaskId = info.TaskId;
            vm.TaskName = _tasksInfo.GetInfoById(info.TaskId).Name;
            vm.Description = info.TaskDescription;
            vm.Status = info.TaskStatus;


			return PartialView("_QualityDetail", vm);

        }


        [HttpGet("/Supervisor/Quality/UpdateStatus")]
        public IActionResult UpdateStatus(int projectId, int taskId)
        {

            long datekey = DateTime.Today.ToDateKey();

            UpdateStatusVM vm = new UpdateStatusVM();

            vm.StatusList.Add(new SelectListItem { Text = "Pending", Value = "Pending" });
            vm.StatusList.Add(new SelectListItem { Text = "In Progress", Value = "InProgress" });
            vm.StatusList.Add(new SelectListItem { Text = "Done", Value = "Done" });

			QualityInfo info = _qualityInfo.GetTask(projectId, taskId, datekey);

            vm.TaskDetail.ProjectId = info.ProjectId;
            vm.TaskDetail.TaskId = info.TaskId;
            vm.TaskDetail.TaskName = _tasksInfo.GetInfoById(info.TaskId).Name;
            vm.TaskDetail.Description = info.TaskDescription;
            vm.TaskDetail.Status = info.TaskStatus;

            return PartialView("_UpdateStatus", vm);

		}


        [HttpPost("/Supervisor/Quality/UpdateStatus")]
        public IActionResult UpdateTaskStatus(UpdateStatusVM vm)
        {

            if (ModelState.IsValid)
            {

                long datekey = DateTime.Today.ToDateKey();

                var check = _qualityInfo.UpdateTaskStatus(vm.TaskDetail.ProjectId, vm.TaskDetail.TaskId, vm.TaskDetail.Status, datekey);

                if (check)
                {
					return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.TaskDetail.ProjectId);
				}

			}

			return Redirect("/Supervisor/Projects/SiteUpdate/" + vm.TaskDetail.ProjectId);

		}


	}
}
