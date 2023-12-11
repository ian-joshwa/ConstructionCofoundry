using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OctaLib.Plugins.MyConstruction.Data;

namespace MyConstruction.Models.ViewModels
{
	public class MaterialVM
	{

		public List<SelectListItem> StocksList { get; set; } = new List<SelectListItem>();

		public MaterialInfo Material { get; set; } = new MaterialInfo();


		[ValidateNever]
		public ProjectStockDetail ProjectStockDetail { get; set; } = new ProjectStockDetail();

	}
}
