using System.Collections.Generic;

namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    public abstract class Strategy : IStrategy
    {
        protected IDictionary<string, string> parametersDictionary { get; set; }

        public abstract ResponseResult Execute();

        public bool ValidateStrategyParam()
        {
            return true;

        }


    }
}
