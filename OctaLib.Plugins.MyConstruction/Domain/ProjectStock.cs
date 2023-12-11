using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Cofoundry.Domain;
using OctaLib.Plugins.Cofoundry;

namespace OctaLib.Plugins.MyConstruction.Domain
{
    [InfoProviderService]
    public class ProjectStockUpdateInfoProvider : IGeneralInfoProvider<ProjectStockUpdateInfo>
    {
        public const string Code = "PRJSTK";
        private readonly ProjectInfoProvider _projectInfoDataProvider;
        private readonly StockInfoProvider _stockInfoProvider;

        public ProjectStockUpdateInfoProvider(
            ProjectInfoProvider projectInfoDataProvider,
            StockInfoProvider stockInfoProvider,
            IDataInfoProvider dataProvider) : base(dataProvider)
        {
            _projectInfoDataProvider = projectInfoDataProvider;
            _stockInfoProvider = stockInfoProvider;
        }

        protected override string GetDC => Code;

        public override ProjectStockUpdateInfo Transform(InfoData<ProjectStockUpdateInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;
            if (depthLevel.GoDeep())
            {
                model.ProjectInfo = _projectInfoDataProvider.GetInfoById(model.ProjectId, depthLevel.NextLevel());
                model.StockInfo = _stockInfoProvider.GetInfoById(model.StockId, depthLevel.NextLevel());
            }
            return model;
        }

        public override ICollection<ProjectStockUpdateInfo> Transform(ICollection<InfoData<ProjectStockUpdateInfo>> data, DataDepthLevel depthLevel)
        {
            var list = data.Select(d => Transform(d, depthLevel)).ToList();
            if (depthLevel.GoDeep())
            {
                var projectIds = list.Select(s => s.ProjectId).Distinct().ToList();
                var stockIds = list.Select(s => s.StockId).Distinct().ToList();

                var projects = _projectInfoDataProvider.GetInfos(projectIds, depthLevel.NextLevel());
                var stocks = _stockInfoProvider.GetInfos(stockIds, depthLevel.NextLevel());

                list.ForEach(item =>
                {
                    item.ProjectInfo = projects.FirstOrDefault(p => p.Id == item.ProjectId);
                    item.StockInfo = stocks.FirstOrDefault(p => p.Id == item.StockId);
                });
            }
            return list;
        }
    }


    public class ProjectStockUpdateInfo : IProjectStockUpdateInfo, ICustomEntityDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public DateTime StatusDate { get; } = DateTime.UtcNow;
        public int StockId { get; set; }
        public StockInfo StockInfo { get; set; }
        public int Old { get; set; }
        public int New { get; set; }
        public int Used { get; set; }
        public int Remaining { get; set; }
    }

    public interface IProjectStockUpdateInfo
    {
        public int ProjectId { get; set; }
        public DateTime StatusDate { get; }
        public int StockId { get; set; }
        public int Old { get; set; }
        public int New { get; set; }
        public int Used { get; set; }
        public int Remaining { get; set; }
    }


}
