using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctaLib.Plugins.MyConstruction.Data.Teams
{
	public class Team
	{
		public int ProjectId { get; set; }
		public int WorkCategoryId { get; set; }
		public int ContractorId { get; set; }
		public int NoOfMen { get; set; }
		public int DateKey { get; set; }
	}
}
