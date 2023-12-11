using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using OctaLib.Plugins.Cofoundry;
using OctaLib.Plugins.MyConstruction.Common.Enum;

namespace OctaLib.Plugins.MyConstruction.Domain
{
    [InfoProviderService]
    public class StockInfoProvider : IGeneralInfoProvider<StockInfo>
    {
        public const string Code = "STKINF";
        private List<StockInfo>? _stocks = null;

        public StockInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }

        protected override string GetDC => Code;

        public override StockInfo Transform(InfoData<StockInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;
            return model;
        }

        public override ICollection<StockInfo> Transform(ICollection<InfoData<StockInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(d => Transform(d, depthLevel)).ToList();
        }

        public ICollection<StockInfo> GetStocks()
        {
            if(_stocks != null)
            {
                return _stocks;
            }

            _stocks = GetInfos()?.ToList() ?? new List<StockInfo>();
            return _stocks;
        }


    }

    public class StockInfo : IStockInfo, ICustomEntityDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public StockTypeUnit StockTypeUnit { get; set; }
    }

    public interface IStockInfo
    {
        public string Name { get; set; }
        public StockTypeUnit StockTypeUnit { get; set; }
    }

}
