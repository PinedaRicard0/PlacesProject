using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class PlacesContext : DbContext
    {
        public PlacesContext() : base("name=DbConnection")
        {
            Database.SetInitializer<PlacesContext>(new CreateDatabaseIfNotExists<PlacesContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Municipality> Municipality { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet <RegionMunicipalities> RegionMunicipalities { get; set; }
    }
}
