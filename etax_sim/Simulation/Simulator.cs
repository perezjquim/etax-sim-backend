using System.Collections.Generic;
using System.Reflection;
using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using eTaxSim.Simulation.SimulationStrategies.Creation;
using log4net;

namespace eTaxSim.Simulation
{
    public class Simulator
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly AppDbContext _context;
        public Country Country { get; set; }
        public Region Region { get; set; }
        public Company Company { get; set; }
        public Sector Sector { get; set; }
        public Role Role { get; set; }
        public Strategy Strategy { get; set; }
        public IDictionary<string, object> ParametersDictionary { get; set; }

        public Simulator(AppDbContext aContext)
        {
            _context = aContext;
        }

        public Simulator(AppDbContext aContext, Country aCountry, Region aRegion, Company aCompany, Sector aSector,
            Role aRole, Strategy aStrategy, IDictionary<string, object> aParametersDictionary)
        {
            _context = aContext;
            Country = aCountry;
            Region = aRegion;
            Company = aCompany;
            Sector = aSector;
            Role = aRole;
            Strategy = aStrategy;
            ParametersDictionary = aParametersDictionary;

            // TODO: log to DB here entry parameters
            logger.Info("Starting Simulation " + Strategy.Name + " for " + Region.Description + ", " +
                        Country.Description);
        }

        public ResponseResult ExecuteSimulation()
        {
            var creator = new StrategyCreator(_context);
            var strategy = creator.FactoryMethod(Country, Region, Strategy, ParametersDictionary);

            var responseResult = strategy.Execute();

            // TODO: log to DB here result parameters
            logger.Info("End of Simulation");
            return responseResult;
        }
    }
}