namespace MyConstruction.Models.ViewModels
{
	public class QualityStatusUpdateVM
	{

		public int ProjectId {  get; set; }
		public string ProjectName { get; set; }

		public List<ProjectTaskDetail> PendingTasks = new List<ProjectTaskDetail>();

		public List<ProjectTaskDetail> InProgressTasks = new List<ProjectTaskDetail>();

		public List<ProjectTaskDetail> CompletedTasks = new List<ProjectTaskDetail>();

	}
}
