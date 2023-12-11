using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectTagsDataModel : IProjectTagsInfo, ICustomEntityDataModel
    {

        [Required]
        public string Name { get; set; }
    }
}
