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
    public class ProjectTaskInfoProvider : IGeneralInfoProvider<ProjectTaskInfo>
    {
        public const string Code = "PRJTSK";
        private List<ProjectTaskInfo>? _tasklist = null;

        public ProjectTaskInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
        {
        }

        protected override string GetDC => Code;

        public override ProjectTaskInfo Transform(InfoData<ProjectTaskInfo> data, DataDepthLevel depthLevel)
        {
            var model = data.Model;
            model.Id = data.Id;
            model.Title = data.Title;
            return model;
        }

        public override ICollection<ProjectTaskInfo> Transform(ICollection<InfoData<ProjectTaskInfo>> data, DataDepthLevel depthLevel)
        {
            return data.Select(d => Transform(d, depthLevel)).ToList();
        }

        public ICollection<ProjectTaskInfo> GetTaskList()
        {
            if(_tasklist != null)
            {
                return _tasklist;
            }

            _tasklist = GetInfos()?.ToList() ?? new List<ProjectTaskInfo>();
            return _tasklist;

        }


    }


    public class ProjectTaskInfo : IProjectTaskInfo, ICustomEntityDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatusUnits Status { get; set; }
    }

    public interface IProjectTaskInfo
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatusUnits Status { get; set; }

    }

}
