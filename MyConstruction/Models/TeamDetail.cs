namespace MyConstruction.Models
{
	public class TeamDetail
	{
		public int ProjectId { get; set; }
		public int WorkCategoryId { get; set; }
		public int ContractorId { get; set; }
		public string ProjectName { get; set; }
		public string WorkCategory { get; set; }
		public string ContractorName { get; set; }
		public int NoOfMen { get; set; }

		public string? ImageUrl { get; set; }
	}
}
