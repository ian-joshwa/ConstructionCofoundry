using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core;
using Cofoundry.Core.AutoUpdate;

namespace OctaLib.Plugins.MyConstruction.Install
{
	public class UpdatePackageFactory : BaseDbOnlyUpdatePackageFactory
	{
		public override string ModuleIdentifier => "MYConstruction";
		public override ICollection<string> DependentModules { get; } = new string[] { CofoundryModuleInfo.ModuleIdentifier };
	}
}
