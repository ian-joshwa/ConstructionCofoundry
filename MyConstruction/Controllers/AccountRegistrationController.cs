using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using MyConstruction.Models;
using OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas;

namespace MyConstruction.Controllers
{
    [Route("/account/registration")]
    [AutoValidateAntiforgeryToken]
    public class AccountRegistrationController : Controller
    {

        private readonly IAdvancedContentRepository _contentRepository;

        public AccountRegistrationController(
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

            var viewModel = new RegisterViewModel();
            return View(viewModel);
        }



        [HttpPost("")]
        public async Task<IActionResult> Index(RegisterViewModel viewModel)
        {

            using (var scope = _contentRepository.Transactions().CreateScope())
            {

                var userId = await _contentRepository
                .WithElevatedPermissions()
                .WithModelState(this)
                .Users()
                .AddAsync(new AddUserCommand()
                {
                    UserAreaCode = AccountUserArea.Code,
                    RoleCode = EmployeeRole.Code,
                    Username = viewModel.Username,
                    Password = viewModel.Password,
                    Email = viewModel.Email
                });


                await _contentRepository
                .WithModelState(this)
                .Users()
                .AccountVerification()
                .EmailFlow()
                .InitiateAsync(new InitiateUserAccountVerificationViaEmailCommand()
                {
                    UserId = userId
                });

                await scope.CompleteIfValidAsync(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return View("RegistrationSuccess", viewModel);

        }


        [Route("Verify")]
        public async Task<IActionResult> Verify(string t)
        {
            await _contentRepository
                .WithModelState(this)
                .Users()
                .AccountVerification()
                .EmailFlow()
                .CompleteAsync(new CompleteUserAccountVerificationViaEmailCommand()
                {
                    UserAreaCode = AccountUserArea.Code,
                    Token = t
                });

            if (ModelState.IsValid)
            {
                return View("VerifySuccess");
            }

            return View();
        }


        [Route("ResendVerification")]
        public async Task<IActionResult> ResendVerification()
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

            return View(new ResendVerificationViewModel());
        }



        [HttpPost("ResendVerification")]
        public async Task<IActionResult> ResendVerification(ResendVerificationViewModel viewModel)
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
                return View();
            }



            await _contentRepository
                .WithModelState(this)
                .Users()
                .AccountVerification()
                .EmailFlow()
                .InitiateAsync(new InitiateUserAccountVerificationViaEmailCommand()
                {
                    UserId = authResult.User.UserId
                });

            if (ModelState.IsValid)
            {
                return View("ResendVerificationSuccess");
            }

            return View();
        }


    }
}
