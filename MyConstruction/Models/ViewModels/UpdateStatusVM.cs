using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyConstruction.Models.ViewModels
{
	public class UpdateStatusVM
	{

		public List<SelectListItem> StatusList { get; set; } = new List<SelectListItem>();

		public ProjectTaskDetail TaskDetail { get; set; } = new ProjectTaskDetail();

	}
}
