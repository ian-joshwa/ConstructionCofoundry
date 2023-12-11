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
    public class WorkCategoryInfoProvider : IGeneralInfoProvider<WorkCategoryInfo>
    {

        public const string DefinitionCode = "WRKCTG";
        private List<WorkCategoryInfo>? _workCategories = null;  

        public WorkCategoryInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }

        protected override string GetDC => DefinitionCode;

        public override WorkCategoryInfo Transform(InfoData<WorkCategoryInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;


            return model;
        }

        public override ICollection<WorkCategoryInfo> Transform(ICollection<InfoData<WorkCategoryInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(x => Transform(x, depthLevel)).ToList();
        }


        public ICollection<WorkCategoryInfo> GetWorkCategories()
        {
            if(_workCategories != null)
            {
                return _workCategories;
            }

            _workCategories = GetInfos()?.ToList() ?? new List<WorkCategoryInfo>();
            return _workCategories;

        }


    }


    public class WorkCategoryInfo : IWorkCategoryInfo, ICustomEntityDataModel
    {

        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Name { get; set; } = "";
    }


    public interface IWorkCategoryInfo
    {
        string Name { get; set; }
    }


}
