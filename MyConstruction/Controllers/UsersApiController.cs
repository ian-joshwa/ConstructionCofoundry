using Cofoundry.Domain;
using Cofoundry.Web;
using Cofoundry.Web.Admin;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyConstruction.Models;
using OctaLib.Plugins.MyConstruction.Data;
using OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas;

namespace MyConstruction.Controllers
{
    [Route("/admin/api/users")]
    [ApiController]
    public class UsersApiController : BaseAdminApiController
    {

        private readonly MyConstructionDbContext _dbContext;
        private readonly IApiResponseHelper _apiResponseHelper;

        public UsersApiController(MyConstructionDbContext dbContext,
            IApiResponseHelper apiResponseHelper)
        {
            _dbContext = dbContext;
            _apiResponseHelper = apiResponseHelper;
        }


        public ActionResult<object[]> Get()
        {

            var users = _dbContext.Users.Where(x => x.UserAreaCode == AccountUserArea.Code).ToList();
            object[] result = new object[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                result[i] = new { Text = users[i].Username, Value = users[i].Username };
            }

            return _apiResponseHelper.SimpleQueryResponse(result);
        }

    }
}
