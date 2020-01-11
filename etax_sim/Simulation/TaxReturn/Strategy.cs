using eTaxSim.Models;
using System.Collections.Generic;

namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    public class Strategy : IStrategy
    {
        public Country Country { get; set; }
        public Region Region { get; set; }

        //public Strategy;

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
