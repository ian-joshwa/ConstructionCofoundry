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
	public class WorkTaskInfoProvider : IGeneralInfoProvider<WorkTaskInfo>
	{

		public const string DefinitionCode = "WRKTSK";
		private ICollection<WorkTaskInfo>? _workTasks = null;

		public WorkTaskInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
		{
		}

		protected override string GetDC => DefinitionCode;

		public override WorkTaskInfo Transform(InfoData<WorkTaskInfo> data, DataDepthLevel depthLevel)
		{
			var model = data.Model;
			model.Id = data.Id;
			model.Title = data.Title;

			return model;
		}

		public override ICollection<WorkTaskInfo> Transform(ICollection<InfoData<WorkTaskInfo>> data, DataDepthLevel depthLevel)
		{
			return data.Select(x => Transform(x, depthLevel)).ToList();
		}


		public ICollection<WorkTaskInfo> GetWorkTasks()
		{

			if(_workTasks != null)
			{
				return _workTasks;
			}

			_workTasks = GetInfos()?.ToList() ?? new List<WorkTaskInfo>();
			return _workTasks;

		}


	}


	public class WorkTaskInfo : IWorkTaskInfo, ICustomEntityDataModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int WorkCategoryId { get; set; }
		public ICollection<int> TaskIds { get; set; }
	}

	public interface IWorkTaskInfo
	{
		public int WorkCategoryId { get; set; }
		public ICollection<int> TaskIds { get; set; }
	}


}
