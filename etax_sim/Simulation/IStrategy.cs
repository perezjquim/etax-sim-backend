using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation.Model;

namespace eTaxSim.Simulation
{
    public interface IStrategy
    {
        ResponseResult Execute();

        void SetStrategyParameters(Country aCountry, Region aRegion, IDictionary<string, object> aParametersDictionary);
    }
}