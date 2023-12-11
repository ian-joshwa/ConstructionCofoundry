using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctaLib.Plugins.MyConstruction.Common.Enum
{
    public enum ProjectRoles
    {
        [Display(Description = "Super Visor")]
        SuperVisor,
        [Display(Description = "Manager")]
        Manager,
        [Display(Description = "Customer")]
        Customer
    }
}
