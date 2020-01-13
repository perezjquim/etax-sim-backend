using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System.Collections.Generic;

namespace eTaxSim.Simulation.Strategy.LiquidSalary
{
    public class LiquidSalary : IStrategy
    {
        public Country Country { get; set; }
        public Region Region { get; set; }


        public ResponseResult Execute()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValidParameters()
        {
            throw new System.NotImplementedException();
        }

        public void SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            throw new System.NotImplementedException();
        }
    }
}
