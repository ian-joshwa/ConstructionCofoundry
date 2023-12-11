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
    public class ProjectTagsInfoProvider : IGeneralInfoProvider<ProjectTagsInfo>
    {
        public const string DefinitionCode = "PRJTGS";
        private List<ProjectTagsInfo>? _list = null;
        public ProjectTagsInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }

        protected override string GetDC => DefinitionCode;

        public override ProjectTagsInfo Transform(InfoData<ProjectTagsInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;

            return model;
        }

        public override ICollection<ProjectTagsInfo> Transform(ICollection<InfoData<ProjectTagsInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(x => Transform(x, depthLevel)).ToList();
        }


        public ICollection<ProjectTagsInfo> GetProjectTags()
        {

            if(_list != null)
            {
                return _list;
            }

            _list = GetInfos()?.ToList() ?? new List<ProjectTagsInfo>();
            return _list;
        }


    }


    public class ProjectTagsInfo : IProjectTagsInfo, ICustomEntityDataModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }
    }

    public interface IProjectTagsInfo
    {
        public string Name { get; set; }
    }


}
