using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Common.Enum;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.General
{
    public class StockDataModel : IStockInfo, ICustomEntityDataModel
    {
        public string Name { get; set; }
        [SelectList(typeof(StockTypeUnit))]
        public StockTypeUnit StockTypeUnit { get; set; }
    }
}
