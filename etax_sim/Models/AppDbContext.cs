using Microsoft.EntityFrameworkCore;

namespace eTaxSim.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CalcPT_IRSPens> mCalcPTIRSPens { get; set; }
        public DbSet<CalcPT_IRSTrabDep> mCalcPTIRSTrabDep { get; set; }
        public DbSet<Company> mCompanies { get; set; }
        public DbSet<Country> mCountries { get; set; }
        public DbSet<Region> mRegions { get; set; }
        public DbSet<Role> mRoles { get; set; }
        public DbSet<Sector> mSectors { get; set; }
        public DbSet<SimulationLog> mSimulationLogs { get; set; }
        public DbSet<SimulationLogParam> mSimulationLogParams { get; set; }
        public DbSet<StrategyParamRule> mSimulationParamRules { get; set; }
        public DbSet<Strategy> mStrategy { get; set; }
        public DbSet<StrategyByCountry> mStrategyByCountry { get; set; }
        public DbSet<StrategyByCountryByRegion> mStrategyByCountryByRegion { get; set; }
        public DbSet<ParamByStrategy> mParamByStrategy { get; set; }

        public DbSet<RuleAllowedValue> mRuleAllowedValue { get; set; }
        public DbSet<ParamAllowedValue> mParamAllowedValue { get; set; }
    }
}