using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctaLib.Plugins.MyConstruction.Common.Enum
{
    public enum TaskStatusUnits
    {
        [Display(Description = "Pending")]
        Pending,
        [Display(Description = "In Progress")]
        InProgress,
        [Display(Description = "Done")]
        Done,
        [Display(Description = "Rejected")]
        Rejected
    }
}
