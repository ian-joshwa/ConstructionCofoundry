using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.EntityFramework;
using Cofoundry.Domain.Data;
using Microsoft.EntityFrameworkCore;
using OctaLib.Plugins.MyConstruction.Data.Materials;
using OctaLib.Plugins.MyConstruction.Data.Teams;

namespace OctaLib.Plugins.MyConstruction.Data
{
    public class MyConstructionDbContext : CofoundryDbContext
    {
        public MyConstructionDbContext(ICofoundryDbContextInitializer cofoundryDbContextInitializer) : base(cofoundryDbContextInitializer)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder
			.HasAppSchema()
				.ApplyConfiguration(new TeamMap())
				.ApplyConfiguration(new MaterialMap());
		}

		public DbSet<Team> Teams { get; set; }
		public DbSet<Material> Materials { get; set; }

    }
}
