using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using MyConstruction.Cofoundry.ApiCalls;
using MyConstruction.Models;
using OctaLib.Plugins.MyConstruction.Common.Enum;
using OctaLib.Plugins.MyConstruction.Data;
using OctaLib.Plugins.MyConstruction.Domain;
using OctaLib.Plugins.MyConstruction.Models.NestedModels;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectDataModel : IProjectInfo, ICustomEntityDataModel
    {
        [Required]
        public string Name { get; set; } = "Save the Entity First";

        [Required]
        public string Address { get; set; } = "Save the Entity First";

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        [SelectList(typeof(PlotUnits), DefaultItemText = "-- Select Lot Area Unit --")]
        public PlotUnits LotAreaUnit { get; set; }

        public double LotArea { get; set; }

        [SelectList(typeof(PlotUnits), DefaultItemText = "-- Select Funished Area Unit --")]
        public PlotUnits FinishedAreaUnit { get; set; }

        public double FinishedArea { get; set; }

        public bool IsPublic { get; set; }

        public bool IsFeatured { get; set; }

        [Number]
        public int SortOrder { get; set; }

        [Display(Name = "Banner Image")]
        [Image]
        public int BannerImageAssetId { get; set; }

        [NestedDataModelCollection(IsOrderable = true)]
        public ICollection<ProjectImageTagDataModel> ProjectImageTags { get; set; }

        [Required]
        [NestedDataModelCollection(IsOrderable = true, MinItems = 1)]
        public ICollection<UserDataModel> Users { get; set; }
    }

}
