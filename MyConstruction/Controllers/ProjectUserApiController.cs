using System.Diagnostics.Metrics;
using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Controllers
{


    [Route("/getProjects")]
    [ApiController]
    public class ProjectUserApiController : Controller
    {

        private readonly ProjectInfoProvider _projectInfoProvider;
        private readonly IApiResponseHelper _apiResponseHelper;
        private readonly IAdvancedContentRepository _contentRepository;

        public ProjectUserApiController(
            ProjectInfoProvider projectInfoProvider,
            IApiResponseHelper apiResponseHelper,
            IAdvancedContentRepository contentRepository)
        {
            _projectInfoProvider = projectInfoProvider;
            _apiResponseHelper = apiResponseHelper;
            _contentRepository = contentRepository;
        }

        public async Task<IActionResult> Index()
        {

            var username = await _contentRepository
                .Users()
                .Current()
                .Get()
                .AsMicroSummary()
                .Map(e => e.DisplayName)
            .ExecuteAsync();



            var projects = _projectInfoProvider.GetProjects().Where(x => x.Users.Any(user => user.Username == username)).ToList();

            return _apiResponseHelper.SimpleQueryResponse(projects);
        }


    }
}
