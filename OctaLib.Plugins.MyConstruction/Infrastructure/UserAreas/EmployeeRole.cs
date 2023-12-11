using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;

namespace OctaLib.Plugins.MyConstruction.Infrastructure.UserAreas
{
    public class EmployeeRole : IRoleDefinition
    {
        public const string Code = "EMP";
        public string Title => "Employee";

        public string RoleCode => Code;

        public string UserAreaCode => AccountUserArea.Code;

        public void ConfigurePermissions(IPermissionSetBuilder builder)
        {
            builder.ApplyAnonymousRoleConfiguration();
        }
    }
}
