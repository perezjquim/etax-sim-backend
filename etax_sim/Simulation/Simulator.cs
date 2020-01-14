using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using eTaxSim.Simulation.SimulationStrategies.Creation;
using System.Collections.Generic;

namespace eTaxSim.Simulation
{
    public class Simulator
    {
        public Country Country { get; set; }
        public Region Region { get; set; }
        public Company Company { get; set; }
        public Sector Sector { get; set; }
        public Role Role { get; set; }
        public Strategy Strategy { get; set; }
        public IDictionary<string, object> ParametersDictionary { get; set; }
        private readonly AppDbContext _context;

        public Simulator(AppDbContext aContext)
        {
            this._context = aContext;
        }
        public Simulator(AppDbContext aContext, Country aCountry, Region aRegion, Company aCompany, Sector aSector, Role aRole, Strategy aStrategy, IDictionary<string, object> aParametersDictionary)
        {
            this._context = aContext;
            this.Country = aCountry;
            this.Region = aRegion;
            this.Company = aCompany;
            this.Sector = aSector;
            this.Role = aRole;
            this.Strategy = aStrategy;
            this.ParametersDictionary = aParametersDictionary;

            // TODO: log here entry parameters
        }

        public ResponseResult ExecuteSimulation()
        {
            var creator = new StrategyCreator(_context);
            var strategy = creator.FactoryMethod(Country, Region, Strategy, ParametersDictionary);

            var responseResult = strategy.Execute();

            // TODO: log here result parameters

            return responseResult;
        }
    }
}
