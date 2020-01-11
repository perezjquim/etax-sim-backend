using eTaxSim.Models;
using eTaxSim.Simulation.LiquidSalary.Strategy;
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
        public IStrategy Strategy { get; set; }
        public IDictionary<string, string> ParametersDictionary { get; set; }

        public Simulator() { }
        public Simulator(Country aCountry, Region aRegion, Company aCompany, Sector aSector, Role aRole, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            this.Country = aCountry;
            this.Region = aRegion;
            this.Company = aCompany;
            this.Sector = aSector;
            this.Role = aRole;
            this.ParametersDictionary = aParametersDictionary;

            Strategy.SetStrategyParameters(Country, Region, aStrategy, ParametersDictionary);
        }

        public ResponseResult ExecuteSimulation()
        {
            var valid = Strategy.IsValidParameters();
            if(!valid) throw new System.ArgumentException("Invalid parameters");

            var responseResult = Strategy.Execute();
            return responseResult;
        }
    }
}
