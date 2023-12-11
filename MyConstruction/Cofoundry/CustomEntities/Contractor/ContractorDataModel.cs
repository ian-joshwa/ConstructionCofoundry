using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using MyConstruction.Cofoundry.CustomEntities.WorkCategory;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Contractor
{
    public class ContractorDataModel : IContractorInfo, ICustomEntityDataModel
    {
        [Display(Name = "Contractor Name")]
        [Required]
        public string Name { get; set; }


        [Display(Name = "Work Categories")]
        [CustomEntityCollection(WorkCategoryDefinition.DefinitionCode)]
        public ICollection<int> WorkCategoryIds { get; set; }
    }
}
