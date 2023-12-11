using System.Diagnostics;
using Cofoundry.Web.Admin;
using Microsoft.AspNetCore.Mvc;
using MyConstruction.Cofoundry.ApiCalls;
using MyConstruction.Models;
using OctaLib.Helpers;
using OctaLib.Plugins.MyConstruction.Data;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectInfoProvider _projectInfoDataProvider;
        private readonly ServiceInfoDataProvider _serviceInfoDataProvider;

        public HomeController(ILogger<HomeController> logger,
            ProjectInfoProvider projectInfoProvider,
            ServiceInfoDataProvider serviceInfoDataProvider)
        {
            _logger = logger;
            _projectInfoDataProvider = projectInfoProvider;
            _serviceInfoDataProvider = serviceInfoDataProvider;
        }

        [Route("/projects/{id}")]
        public IActionResult ProjectDetail(string id)
        {
            var project = _projectInfoDataProvider.GetInfoBySlug(id);
            if (project == null || !project.IsPublished)
                return NotFound();
            return View(nameof(ProjectDetail), project);
        }

        [Route("/services/{id}")]
        public IActionResult ServiceDetails(string id)
        {
            var service = _serviceInfoDataProvider.GetInfoBySlug(id);
            if (service == null || !service.IsPublished)
            {
                return NotFound();
            }
            return View(nameof(ServiceDetails), service);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}