using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OctaLib.Plugins.MyConstruction.Data.Materials
{
	public class MaterialMap : IEntityTypeConfiguration<Material>
	{
		public void Configure(EntityTypeBuilder<Material> builder)
		{
			builder.ToTable(nameof(Material), DbConstants.DefaultAppSchema);
			builder.HasKey(e => new { e.ProjectId, e.StockId, e.Datekey });
		}
	}
}
