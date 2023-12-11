using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Plugins.AMLab;
using OctaLib.Plugins.Cofoundry;

namespace OctaLib.Plugins.MyConstruction.Data
{
	[InfoProviderService]
	public class MaterialInfoProvider
	{
		public MaterialInfoProvider()
		{
		}

		public List<MaterialInfo> GetAllMaterials(int projectId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("datekey", datekey)
				.SpList<MaterialInfo>("dbo.GetAllMaterials")?.ToList() ?? new List<MaterialInfo>();
		}

		public MaterialInfo GetMaterial(int projectId, int stockId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("stockId", stockId)
				.AddParam("datekey", datekey)
				.Sp<MaterialInfo>("dbo.GetMaterial");
		}


		public bool AddMaterial(int projectId, int stockId, int newStock, int usedStock, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("stockId", stockId)
				.AddParam("newStock", newStock)
				.AddParam("usedStock", usedStock)
				.AddParam("datekey", datekey)
				.Exec("dbo.AddMaterial");
		}

		public bool MaterialEdit(int projectId, int stockId, int newStock, int usedStock, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("stockId", stockId)
				.AddParam("newStock", newStock)
				.AddParam("usedStock", usedStock)
				.AddParam("datekey", datekey)
				.Exec("dbo.Material_Edit");
		}

		public bool MaterialDelete(int projectId, int stockId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("stockId", stockId)
				.AddParam("datekey", datekey)
				.Exec("dbo.Material_Delete");
		}



	}


	public class MaterialInfo
	{
		public int ProjectId { get; set; }
		public int StockId { get; set; }
		public int NewStock { get; set; }
		public int UsedStock { get; set; }
		public int Datekey { get; set; }
	}


}
