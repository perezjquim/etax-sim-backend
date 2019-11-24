using Microsoft.EntityFrameworkCore;

namespace etax_sim.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CalcPT_IRSPens> mCalcPTIRSPens { get; set; }
        public DbSet<CalcPT_IRSTrabDep> mCalcPTIRSTrabDep { get; set; }        
        public DbSet<Company> mCompanies { get; set; }                
        public DbSet<Country> mCountries { get; set; }
        public DbSet<Region> mRegions { get; set; }
        public DbSet<Role> mRoles { get; set; }
        public DbSet<Sector> mSectors { get; set; }
	public DbSet<SimulationLog> mSimulationLogs { get; set; }        
	public DbSet<SimulationLogParam> mSimulationLogParams { get; set; }	
	public DbSet<SimulationParamRule> mSimulationParamRules { get; set; }
    }
}