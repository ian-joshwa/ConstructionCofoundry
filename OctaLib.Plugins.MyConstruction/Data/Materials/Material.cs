using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctaLib.Plugins.MyConstruction.Data.Materials
{
	public class Material
	{
		public int ProjectId { get; set; }
		public int StockId { get; set; }
		public int NewStock { get; set; }
		public int UsedStock { get; set; }
		public int Datekey { get; set; }
	}
}
