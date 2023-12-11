using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctaLib.Plugins.MyConstruction.Common.Enum
{
    public enum StockTypeUnit
    {
        [Display(Description = "Blocks")]
        Blocks,
        [Display(Description = "Bags")]
        Bags,
        [Display(Description = "KG")]
        KG
    }
}
