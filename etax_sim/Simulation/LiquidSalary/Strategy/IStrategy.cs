using System.Collections.Generic;

namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    public interface IStrategy
    {

        ResponseResult Execute();

        bool ValidateStrategyParam();

        IDictionary<string, string> parametersDictionary { get; set; }



    }
}
