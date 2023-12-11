using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using OctaLib.Helpers;
using OctaLib.Plugins.Cofoundry;

namespace OctaLib.Plugins.MyConstruction.Domain
{
    [InfoProviderService]
    public class ServiceInfoDataProvider : IGeneralInfoProvider<ServiceInfo>
    {
        public const string DefinitionCode = "SRVICE";
        private List<ServiceInfo>? _services = null;

        public ServiceInfoDataProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {

        }

        protected override string GetDC => DefinitionCode;

        public override ServiceInfo Transform(InfoData<ServiceInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;
            model.Slug = data.UrlSlug;
            data.Status = data.Status;
            return model;
        }

        public override ICollection<ServiceInfo> Transform(ICollection<InfoData<ServiceInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(d => Transform(d, depthLevel)).ToList();
        }
        public ICollection<ServiceInfo> GetFeatured()
        {
            return GetServices()
                    .Where(d => d.IsFeatured).ToList() ??
                    new List<ServiceInfo>();
        }

        public ServiceInfo? GetInfoBySlug(string slug)
        {
            if (slug.IsEmpty())
            {
                return null;
            }                  
            slug = slug.ToLower();
			slug = slug.Replace(" ", "-");
			return GetServices().FirstOrDefault(s => slug.Equals(s.Slug));
        }

        public ICollection<ServiceInfo> GetServices()
        {
            if (_services != null)
            {
                return _services;
            }

            _services = GetInfos()?.ToList() ?? new List<ServiceInfo>();
            return _services;
        }
    }

    public class ServiceInfo : IServiceInfo, ICustomEntityDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int BannerImageId { get; set; }
        public int HeaderImageId { get; set; }
        public bool IsFeatured { get; set; }
        public string Slug { get; internal set; }
        public PublishStatus Status { get; set; }
        public bool IsPublished => Status == PublishStatus.Published;
    }
    public interface IServiceInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BannerImageId { get; set; }
        public int HeaderImageId { get; set; }
        public bool IsFeatured { get; set; }

    }

}
