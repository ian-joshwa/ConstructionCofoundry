using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OctaLib.Plugins.MyConstruction.Data;
using OctaLib.Plugins.MyConstruction.Data.Teams;

namespace MyConstruction.Models.ViewModels
{
	public class TeamVM
	{

		public IEnumerable<SelectListItem> WorkCategories { get; set; } = new List<SelectListItem>();
		public TeamInfo Team { get; set; } = new TeamInfo();


		[ValidateNever]
		public TeamDetail TeamDetail { get; set; } = new TeamDetail();

	}
}
