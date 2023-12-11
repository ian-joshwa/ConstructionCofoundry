using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using MyConstruction.Cofoundry.CustomEntities.WorkCategory;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
	public class WorkTaskDataModel : IWorkTaskInfo, ICustomEntityDataModel
	{

		[Required]
		[CustomEntity(WorkCategoryDefinition.DefinitionCode)]
		public int WorkCategoryId { get; set; }

		[Required]
		[CustomEntityCollection(TaskDefinition.DefinitionCode, IsOrderable = true)]

		public ICollection<int> TaskIds { get; set; }

	}
}
