using Microsoft.EntityFrameworkCore;
namespace etax_sim.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Country> countries { get; set; }
    }
}