using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class SiteUpdateDataModel : ISiteUpdateInfo, ICustomEntityDataModel
    {
        [Required]
        [CustomEntity(ProjectDefinition.DefinitionCode)]
        public int ProjectId { get; set; }

        [ReadOnly]
        public DateTime StatusDate { get; } = DateTime.UtcNow;

        [Required]
        public int NumberOfMasons { get; set; }

        [Required]
        public int NumberOfLabourMen { get; set; }

        [ImageCollection]
        public ICollection<int>? SiteImagesIds { get; set; }
    }
}
