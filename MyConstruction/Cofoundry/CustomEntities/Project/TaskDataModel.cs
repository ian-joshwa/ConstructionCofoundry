using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
	public class TaskDataModel : ITaskInfo, ICustomEntityDataModel
	{
		[Required]
		public string Name { get; set; }
	}
}
