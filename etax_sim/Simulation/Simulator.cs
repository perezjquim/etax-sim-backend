using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation.LiquidSalary.Strategy;

namespace eTaxSim.Simulation
{
    public class Simulator
    {
        private Country Country { get; set; }
        private Region Region { get; set; }
        private Company Company { get; set; }
        private Sector Sector { get; set; }
        private Role Role { get; set; }
        private string Strategy { get; set; }
        private IDictionary<string, string> ParametersDictionary { get; set; }

        public Simulator() { }
        public Simulator(Country aCountry, Region aRegion, Company aCompany, Sector aSector, Role aRole, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            this.Country = aCountry;
            this.Region = aRegion;
            this.Company = aCompany;
            this.Sector = aSector;
            this.Role = aRole;
            this.Strategy = aStrategy;
            this.ParametersDictionary = aParametersDictionary;
        }

        public void ExecuteSimulation()
        {

        }

        private IStrategy GetStrategyByName(string name)
        {
            IStrategy strategy = null;

            return strategy;
        }

        private bool ValidateStrategyParam;
    }
}
