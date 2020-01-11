using System.Collections.Generic;
using eTaxSim.Models;

namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    public interface IStrategy
    {
        ResponseResult Execute();

        bool IsValidParameters();

        void SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary);
    }
}
