using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using etax_sim.Models;
using etax_sim.Simulation.LiquidSalary.Strategy;

namespace etax_sim.Simulation
{
    public class Simulator
    {
        private Country Country { get; set; }
        private Region Region { get; set; }
        private Company Company { get; set; }
        private Sector Sector { get; set; }
        private Role Role { get; set; }
        private IDictionary<IStrategy, IDictionary<string, string>> strategyDictionary { get; set; }
        private IDictionary<string, string> asd { get; set; }

        public Simulator() { }
        public Simulator(Country aCountry, Region aRegion, Company aCompany, Sector aSector, Role aRole, IDictionary<IStrategy, IDictionary<string, string>> aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            this.Country = aCountry;
            this.Region = aRegion;
            this.Company = aCompany;
            this.Sector = aSector;
            this.Role = aRole;
            this.strategyDictionary = aStrategy;
        }

        public double ExecuteSimulation()
        {
            double result;

            foreach (var keyValuePair in strategyDictionary)
            {
                var strategy = keyValuePair.Key;
                strategy.Execute(keyValuePair.Value);
            }

            return result;
        }
        

    }
}
