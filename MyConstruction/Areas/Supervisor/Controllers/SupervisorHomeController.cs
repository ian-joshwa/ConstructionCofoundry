using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas;

namespace MyConstruction.Areas.Supervisor.Controllers
{
    [Area("Supervisor")]
    [AuthorizeUserArea(AccountUserArea.Code)]
    [Route("/Supervisor")]
    public class SupervisorHomeController : Controller
    {

        private readonly IAdvancedContentRepository _contentRepository;

        public SupervisorHomeController(IAdvancedContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [Route("")]
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
    }
}
