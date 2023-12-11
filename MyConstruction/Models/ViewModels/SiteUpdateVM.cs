using OctaLib.Plugins.MyConstruction.Data.Teams;

namespace MyConstruction.Models.ViewModels
{
	public class SiteUpdateVM
	{

		public int projectId { get; set; }

		public bool TeamShow { get; set; }
		public bool MaterialShow { get; set; }
		public IEnumerable<TeamDetail> Teams { get; set; } = new List<TeamDetail>();
		public IEnumerable<MaterialDetail> Materials { get; set; } = new List<MaterialDetail>();
		public IEnumerable<ProjectTaskDetail> ProjectTasks { get; set; } = new List<ProjectTaskDetail>();
	}
}
