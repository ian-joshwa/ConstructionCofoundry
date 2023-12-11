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
	public class TasksInfoProvider : IGeneralInfoProvider<TaskInfo>
	{

		public const string DefinitionCode = "TTSSKK";
		private List<TaskInfo>? _list = null;

		public TasksInfoProvider(IDataInfoProvider dataProvider) : base(dataProvider)
		{
		}

		protected override string GetDC => DefinitionCode;

		public override TaskInfo Transform(InfoData<TaskInfo> data, DataDepthLevel depthLevel)
		{
			var model = data.Model;
			model.Id = data.Id;
			model.Title = data.Title;

			return model;
		}

		public override ICollection<TaskInfo> Transform(ICollection<InfoData<TaskInfo>> data, DataDepthLevel depthLevel)
		{
			return data.Select(x => Transform(x, depthLevel)).ToList();	
		}

		public ICollection<TaskInfo> GetTask()
		{

			if(_list != null)
			{
				return _list;
			}

			_list = GetInfos()?.ToList() ?? new List<TaskInfo>();
			return _list;

		}


	}


	public class TaskInfo : ITaskInfo, ICustomEntityDataModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Name { get; set; } = "";
	}


	public interface ITaskInfo
	{
		public string Name { get; set; }
	}


}
