using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;

namespace OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas
{
    public class AccountUserArea : IUserAreaDefinition
    {
        public const string Code = "ACC";
        public string UserAreaCode => Code;

        public string Name => "Account";

        public bool AllowPasswordSignIn => true;

        public bool UseEmailAsUsername => false;

        public string SignInPath => "/account/auth";

        public bool IsDefaultAuthScheme => true;

        public void ConfigureOptions(UserAreaOptions options)
        {
            options.AccountVerification.VerificationUrlBase = "/account/registration/verify";
            options.AccountVerification.RequireVerification = true;
            options.Username.UseAsDisplayName = true;
        }
    }
}
