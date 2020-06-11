using Microsoft.EntityFrameworkCore;

namespace BikePath.Models
{
    public class BikePathContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }

        public BikePathContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bikePath;Trusted_Connection=True;");
        }
    }
}
