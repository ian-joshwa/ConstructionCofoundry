using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OctaLib.Plugins.MyConstruction.Common.Enum;

namespace MyConstruction.Models
{
	public class ProjectTaskDetail
	{
		public int ProjectId { get; set; }
		public int TaskId { get; set; }

		[ValidateNever]
		public string TaskName { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
	}
}
