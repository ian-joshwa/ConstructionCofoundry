using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Plugins.AMLab;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OctaLib.Plugins.Cofoundry;
using OctaLib.Plugins.MyConstruction.Common.Enum;

namespace OctaLib.Plugins.MyConstruction.Data
{
	[InfoProviderService]
	public class QualityInfoProvider
	{
		public QualityInfoProvider()
		{
		}

		public bool AddQuality(QualityInfo vm)
		{
			return OctaLibDbService
				.AddParam("projectId", vm.ProjectId)
				.AddParam("taskId", vm.TaskId)
				.AddParam("taskDescription", vm.TaskDescription)
				.AddParam("taskStatus", vm.TaskStatus)
				.AddParam("datekey", vm.Datekey)
				.Exec("dbo.Task_Add");
		}


		public bool EditQuality(int projectId, int taskId, string descrip, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("taskId", taskId)
				.AddParam("taskDescription", descrip)
				.AddParam("datekey", datekey)
				.Exec("dbo.Task_Edit");
		}


		public bool DeleteQuality(int projectId, int taskId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("taskId", taskId)
				.AddParam("datekey", datekey)
				.Exec("dbo.Task_Delete");
		}

		public List<QualityInfo> GetAllTasks(int projectId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("datekey", datekey)
				.SpList<QualityInfo>("dbo.SelectAllTasks")?.ToList() ?? new List<QualityInfo>();
		}


		public QualityInfo GetTask(int projectId, int taskId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("taskId", taskId)
				.AddParam("datekey", datekey)
				.Sp<QualityInfo>("dbo.SelectTask");
		}


		public List<QualityInfo> GetPendingTasks(int projectId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("datekey", datekey)
				.SpList<QualityInfo>("dbo.GetPendingTasks ")?.ToList() ?? new List<QualityInfo>(); 
		}


		public bool UpdateTaskStatus(int projectId, int taskId, string status, long datekey)
		{

			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("taskId", taskId)
				.AddParam("taskStatus", status)
				.AddParam("datekey", datekey)
				.Exec("dbo.Task_UpdateStatus");

		}


	}


	public class QualityInfo
	{
		public int ProjectId { get; set; }
		public int TaskId { get; set; }

		[ValidateNever]
		public string TaskDescription { get; set; } = "Nothing.";
		public string TaskStatus { get; set; }
		public long Datekey { get; set; }
	}

}
