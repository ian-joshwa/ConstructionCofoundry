using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using OctaLib.Plugins.Cofoundry;

namespace OctaLib.Plugins.MyConstruction.Domain
{
    [InfoProviderService]
    public class ContractorInfoProvider : IGeneralInfoProvider<ContractorInfo>
    {
        public const string DefinitionCode = "CNTATR";
        private List<ContractorInfo>? _contractors = null;

        public ContractorInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }

        protected override string GetDC => DefinitionCode;

        public override ContractorInfo Transform(InfoData<ContractorInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;

            return model;
        }

        public override ICollection<ContractorInfo> Transform(ICollection<InfoData<ContractorInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(x => Transform(x, depthLevel)).ToList();
        }

        public ICollection<ContractorInfo> GetContractors()
        {
            if(_contractors != null)
            {
                return _contractors;
            }

            _contractors = GetInfos()?.ToList() ?? new List<ContractorInfo>();
            return _contractors;

        }




    }




    public class ContractorInfo : IContractorInfo, ICustomEntityDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Name { get; set; } = "";
        public ICollection<int> WorkCategoryIds { get; set; }
    }

    public interface IContractorInfo
    {
        public string Name { get; set; }
        public ICollection<int> WorkCategoryIds { get; set; }
    }


}
