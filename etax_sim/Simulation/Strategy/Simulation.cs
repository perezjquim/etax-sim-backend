using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System;
using System.Collections.Generic;

namespace eTaxSim.Simulation.Strategy
{
    public abstract class Simulation : IStrategy
    {
        public abstract ResponseResult Execute();

        public bool IsValidParameters()
        {
            return true;
        }

        public void SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
