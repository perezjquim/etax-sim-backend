using eTaxSim.Models;
using System.Collections.Generic;
using eTaxSim.Simulation.Model;

namespace eTaxSim.Simulation
{
    public interface IStrategyGlobal
    {
        ResponseResult Execute();

        bool IsValidParameters();

        void SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary);
    }
}
