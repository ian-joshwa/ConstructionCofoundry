using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OctaLib.Plugins.MyConstruction.Common.Enum;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectTaskDataModel : IProjectTaskInfo, ICustomEntityDataModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [CustomEntity(ProjectDefinition.DefinitionCode)]
        public int ProjectId { get; set; }
        [Required]
        [Html(HtmlToolbarPreset.AdvancedFormatting)]
        public string Description { get; set; } = "Save Entity First";

        [SelectList(typeof(TaskStatusUnits))]
        public TaskStatusUnits Status { get; set; }
    }
}
