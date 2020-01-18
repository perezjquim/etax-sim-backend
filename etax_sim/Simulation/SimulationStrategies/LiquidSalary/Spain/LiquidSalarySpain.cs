using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Spain
{
    internal class LiquidSalarySpain : IStrategy
    {
        private const string I_BASE_SALARY = "base_salary";
        private const string I_NO_SALARY = "no_salary";
        private const string O_LIQUID_SALARY = "liquid_salary";
        protected Country Country { get; set; }
        protected Region Region { get; set; }
        protected Parameters Param { get; set; }
        protected LiquidSalarySpainModel model { get; set; }

        public void SetStrategyParameters(Country aCountry, Region aRegion,
            IDictionary<string, object> aParametersDictionary)
        {
            Country = aCountry;
            Region = aRegion;
            Param = new Parameters(aParametersDictionary);

            model = new LiquidSalarySpainModel();
            LoadParamToModel();
        }

        public ResponseResult Execute()
        {
            var calculator = new LiquidSalarySpainCalculator(model);
            calculator.Calculate();

            IDictionary<string, object> returnParameters = new Dictionary<string, object>();

            returnParameters.Add(O_LIQUID_SALARY, model.LiquidSalary);

            var result = new ResponseResult {Parameters = returnParameters};
            return result;
        }

        private void LoadParamToModel()
        {
            model.BaseSalary = Param.GetDouble(I_BASE_SALARY);
            model.NumberSalary = Param.GetInt(I_NO_SALARY);

            RedefineModel();
        }

        protected virtual void RedefineModel() { }
    }
}