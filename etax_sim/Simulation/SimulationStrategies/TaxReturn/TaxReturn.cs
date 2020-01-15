using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System.Collections.Generic;

namespace eTaxSim.Simulation.SimulationStrategies.TaxReturn
{
    public class TaxReturn : IStrategy
    {
        public Country Country { get; set; }
        public Region Region { get; set; }

        //public Strategy;


        public ResponseResult Execute()
        {
            throw new System.NotImplementedException();
        }

        public void SetStrategyParameters(Country aCountry, Region aRegion, IDictionary<string, object> aParametersDictionary)
        {
            throw new System.NotImplementedException();
        }
    }
}
