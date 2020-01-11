using System.Collections.Generic;
using eTaxSim.Models;

namespace eTaxSim.Simulation
{
    public interface IStrategy
    {
        ResponseResult Execute();

        bool IsValidParameters();

        void SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary);
    }
}
