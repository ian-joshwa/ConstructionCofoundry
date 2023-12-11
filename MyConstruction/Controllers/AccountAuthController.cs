using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using MyConstruction.Models;
using OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas;

namespace MyConstruction.Controllers
{

    [Route("/account/auth")]
    [AutoValidateAntiforgeryToken]
    public class AccountAuthController : Controller
    {

        private readonly IAdvancedContentRepository _contentRepository;

        public AccountAuthController(
            IAdvancedContentRepository contentRepository
            )
        {
            _contentRepository = contentRepository;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var isSignedIn = await _contentRepository
            .Users()
            .Current()
            .IsSignedIn()
            .ExecuteAsync();

            if (isSignedIn)
            {
                return Redirect("/Supervisor");
            }

            var viewModel = new SignInViewModel();
            return View(viewModel);
        }


        [HttpPost("")]
        public async Task<IActionResult> Index(SignInViewModel viewModel)
        {
            var authResult = await _contentRepository
                .WithModelState(this)
                .Users()
                .Authentication()
                .AuthenticateCredentials(new AuthenticateUserCredentialsQuery()
                {
                    UserAreaCode = AccountUserArea.Code,
                    Username = viewModel.Username,
                    Password = viewModel.Password
                })
                .ExecuteAsync();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var returnUrl = RedirectUrlHelper.GetAndValidateReturnUrl(this);

            if (authResult.User.RequirePasswordChange)
            {
            }

            if (!authResult.User.IsAccountVerified)
            {
                return View("VerificationRequired");
            }

            await _contentRepository
                .Users()
                .Authentication()
                .SignInAuthenticatedUserAsync(new SignInAuthenticatedUserCommand()
                {
                    UserId = authResult.User.UserId,
                    RememberUser = true
                });

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            return Redirect("/Supervisor");
        }


        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _contentRepository
                .Users()
                .Authentication()
                .SignOutAsync();

            return View();
        }


    }
}
