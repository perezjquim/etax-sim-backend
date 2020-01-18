using System;
using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation.Model;

namespace eTaxSim.Simulation.SimulationStrategies.TaxReturn
{
    public class TaxReturn : IStrategy
    {
        public Country Country { get; set; }
        public Region Region { get; set; }


        public ResponseResult Execute()
        {
            throw new NotImplementedException();
        }

        public void SetStrategyParameters(Country aCountry, Region aRegion,
            IDictionary<string, object> aParametersDictionary)
        {
            throw new NotImplementedException();
        }
    }
}