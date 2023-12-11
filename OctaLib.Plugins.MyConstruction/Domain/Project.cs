using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using OctaLib.Helpers;
using OctaLib.Plugins.Cofoundry;
using OctaLib.Plugins.MyConstruction.Common.Enum;
using OctaLib.Plugins.MyConstruction.Models.NestedModels;

namespace OctaLib.Plugins.MyConstruction.Domain
{
    [InfoProviderService]
    public class ProjectInfoProvider : IGeneralInfoProvider<ProjectInfo>
    {
        public const string DefinitionCode = "PROJCT";
        private List<ProjectInfo>? _projects = null;

        public ProjectInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }


        protected override string GetDC => DefinitionCode;

        public override ProjectInfo Transform(InfoData<ProjectInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Slug = data.UrlSlug.ToLower();
            model.Title = data.Title;
            data.Status = data.Status;
            return model;
        }

        public override ICollection<ProjectInfo> Transform(ICollection<InfoData<ProjectInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(d => Transform(d, depthLevel)).ToList();
        }

        public ICollection<ProjectInfo> GetFeaturedProjects()
        {
            return GetProjects()
                .Where(d => d.IsFeatured)
                .ToList() ?? new List<ProjectInfo>();
        }


        public ICollection<ProjectInfo> GetProjects()
        {
            if (_projects != null)
            {
                return _projects;
            }

            _projects = GetInfos()?.ToList() ?? new List<ProjectInfo>();
            return _projects;
        }
        public ProjectInfo? GetInfoBySlug(string slug)
        {
            if (slug.IsEmpty())
            {
                return null;
            }

            slug = slug.ToLower();
            slug = slug.Replace(" ", "-");
			return GetProjects().FirstOrDefault(p => slug.Equals(p.Slug));
        }
    }

    public class ProjectInfo : IProjectInfo, ICustomEntityDataModel

    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public PlotUnits LotAreaUnit { get; set; }
        public double LotArea { get; set; }
        public PlotUnits FinishedAreaUnit { get; set; }
        public double FinishedArea { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFeatured { get; set; }
        public int SortOrder { get; set; }
        public int BannerImageAssetId { get; set; }
        public ICollection<ProjectImageTagDataModel> ProjectImageTags { get; set; }
        public ICollection<UserDataModel> Users { get; set; }
        public string Slug { get; internal set; }
        public PublishStatus Status { get; set; }
        public bool IsPublished => Status == PublishStatus.Published;
    }

    public interface IProjectInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public PlotUnits LotAreaUnit { get; set; }
        public double LotArea { get; set; }
        public PlotUnits FinishedAreaUnit { get; set; }
        public double FinishedArea { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFeatured { get; set; }
        public int SortOrder { get; set; }
        public ICollection<UserDataModel> Users { get; set; }
        public ICollection<ProjectImageTagDataModel> ProjectImageTags { get; set; }
        public int BannerImageAssetId { get; set; }
    }



}
