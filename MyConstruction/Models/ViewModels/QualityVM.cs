using Microsoft.AspNetCore.Mvc.Rendering;
using OctaLib.Plugins.MyConstruction.Data;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Models.ViewModels
{
	public class QualityVM
	{
		public IEnumerable<SelectListItem> WorkCategoryList { get; set; } = new List<SelectListItem>();
		public QualityInfo Quality { get; set; } = new QualityInfo();
	}
}
