using System.Collections.Generic;

namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    public abstract class Strategy : IStrategy
    {
        protected IDictionary<string, string> parametersDictionary { get; set; }

        public ResponseResult Execute()
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<string, string> GetParametersDictionary()
        {
            throw new System.NotImplementedException();
        }

        public void SetParametersDictionary()
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateStrategyParam()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
