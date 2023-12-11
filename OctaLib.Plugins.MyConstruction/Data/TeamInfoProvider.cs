using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Plugins.AMLab;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OctaLib;
using OctaLib.Plugins.Cofoundry;

namespace OctaLib.Plugins.MyConstruction.Data
{
	[InfoProviderService]
	public class TeamInfoProvider
	{
		public TeamInfoProvider() { }

		public List<TeamInfo> GetAllTeams(int projectId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("datekey", datekey)
				.SpList<TeamInfo>("dbo.SelectAllTeams")?.ToList() ?? new List<TeamInfo>();
		}

		public TeamInfo GetTeam(int projectId, int workCategoryId, int contractorId, long datekey) 
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("workCategoryId", workCategoryId)
				.AddParam("contractorId", contractorId)
				.AddParam("datekey", datekey)
				.Sp<TeamInfo>("dbo.SelectTeam");
		}


		public bool TeamDelete(int projectId, int workCategoryId, int contractorId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("workCategoryId", workCategoryId)
				.AddParam("contractorId", contractorId)
				.AddParam("datekey", datekey)
				.Exec("dbo.Team_Delete");
		}

		public bool TeamEdit(int projectId, int workCategoryId, int contractorId, int noOfMen, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("workCategoryId", workCategoryId)
				.AddParam("contractorId", contractorId)
				.AddParam("noOfMen", noOfMen)
				.AddParam("datekey", datekey)
				.Exec("app.Team_Edit");
		}

		public bool TeamAdd(int projectId, int workCategoryId, int contractorId, int noOfMen, string imageUrl, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("workCategoryId", workCategoryId)
				.AddParam("contractorId", contractorId)
				.AddParam("noOfMen", noOfMen)
				.AddParam("imageUrl", imageUrl)
				.AddParam("datekey", datekey)
				.Exec("dbo.AddTeam");
		}

		public List<TeamInfo> GetTeams_ByProjectID_ByWorkCategoryId(int projectId, int workCategoryId, long datekey)
		{
			return OctaLibDbService
				.AddParam("projectId", projectId)
				.AddParam("workCategoryId", workCategoryId)
				.AddParam("datekey", datekey)
				.SpList<TeamInfo>("dbo.GetTeams_ByProjectId_ByWorkCategoryId")?.ToList() ?? new List<TeamInfo>();
		}


	}
	public class TeamInfo
	{
		public int ProjectId { get; set; }
		public int WorkCategoryId { get; set; }
		public int ContractorId { get; set; }
		[Required]
		[Range(minimum:1, maximum:100)]
		public int NoOfMen { get; set; }

		public string? ImageUrl { get; set; }
		public int DateKey { get; set; }
	}
}
