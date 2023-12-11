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
    public class SiteUpdateInfoDataProvider : IGeneralInfoProvider<SiteUpdateInfo>
    {
        public const string Code = "SITUPD";

        public SiteUpdateInfoDataProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }

        protected override string GetDC => Code;

        public override SiteUpdateInfo Transform(InfoData<SiteUpdateInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;


            return model;
        }

        public override ICollection<SiteUpdateInfo> Transform(ICollection<InfoData<SiteUpdateInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(d => Transform(d, depthLevel)).ToList();
        }
    }


    public class SiteUpdateInfo : ISiteUpdateInfo, ICustomEntityDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int ProjectId { get; set; }
        public DateTime StatusDate { get; } = DateTime.UtcNow;
        public int NumberOfMasons { get; set; }
        public int NumberOfLabourMen { get; set; }
        public ICollection<int>? SiteImagesIds { get; set; }

    }

    public interface ISiteUpdateInfo
    {
        public int ProjectId { get; set; }
        public DateTime StatusDate { get; }
        public int NumberOfMasons { get; set; }
        public int NumberOfLabourMen { get; set; }
        public ICollection<int> SiteImagesIds { get; set; }
    }

}
