using CountriesInformation.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformation.DataAccess.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
