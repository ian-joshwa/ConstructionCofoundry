using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OctaLib.Plugins.MyConstruction.Data.Teams
{
	public class TeamMap : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{
			builder.ToTable(nameof(Team), DbConstants.DefaultAppSchema);
			builder.HasKey(e => new { e.ProjectId, e.WorkCategoryId, e.ContractorId });
		}
	}
}
