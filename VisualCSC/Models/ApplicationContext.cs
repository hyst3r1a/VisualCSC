using Microsoft.EntityFrameworkCore;

namespace VisualCSC
{
    public class ApplicationContext : DbContext
    {
        public DbSet<VisualCSC.Data.Checkin> Checkins { get; set; }
        public DbSet<VisualCSC.Data.Person> Persons { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ec2-54-247-79-178.eu-west-1.compute.amazonaws.com;Port=5432;Username=ovsfgokjbpnaqb;Password=9905638236eb63a00d596cb9a23c9abbb8d6a99e989f274d3a0a51d55dd61ea4;Database=d155umort36eq8;SslMode=Require;Trust Server Certificate=true");
        }
    }
}