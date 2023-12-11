using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctaLib.Plugins.MyConstruction.Common.Enum
{
    public enum PlotUnits
    {
        [Display(Description = "Kanal")]
        kanal,
        [Display(Description = "Marla")]
        marla,
        [Display(Description = "Square Feet")]
        squareFeet,
        [Display(Description = "Square Yards")]
        squareYards,
        [Display(Description = "Square Meters")]
        squareMeters
    }
}
