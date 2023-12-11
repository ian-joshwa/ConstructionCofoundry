using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Service
{
    public class ServiceDataModel : IServiceInfo, ICustomEntityDataModel
    {
        [Required]
        public string Name { get; set; } = "Save the Entity First";

        [Required]
        [Html(HtmlToolbarPreset.AdvancedFormatting)]
        public string Description { get; set; } = "Save the Entity First";

        [Image]
        public int BannerImageId { get; set; }

        [Image]
        public int HeaderImageId { get; set; }
        public bool IsFeatured { get; set; }
    }
}
