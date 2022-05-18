using Microsoft.EntityFrameworkCore;

namespace PriceCounter
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients => Set<Client>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ventilUA.dbo");
        }
    }
}
