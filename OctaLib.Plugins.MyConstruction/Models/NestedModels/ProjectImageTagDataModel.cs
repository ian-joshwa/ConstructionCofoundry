using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace OctaLib.Plugins.MyConstruction.Models.NestedModels
{
    public class ProjectImageTagDataModel : INestedDataModel
    {

        [PreviewTitle]
        [Required]
        [CustomEntity(ProjectTagsInfoProvider.DefinitionCode)]
        public int ProjectTagId { get; set; }


        [PreviewImage]
        [Image]
        [Display(Name = "Image")]
        public int ProjectTagImageId { get; set; }

    }
}
