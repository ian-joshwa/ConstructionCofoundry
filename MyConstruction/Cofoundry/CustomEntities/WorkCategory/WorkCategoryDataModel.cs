using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.WorkCategory
{
    public class WorkCategoryDataModel : IWorkCategoryInfo, ICustomEntityDataModel
    {
        [Required]
        public string Name { get; set; }
    }
}
