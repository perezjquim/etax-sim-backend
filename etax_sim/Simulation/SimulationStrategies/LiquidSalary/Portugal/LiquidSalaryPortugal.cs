using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal
{
    internal class LiquidSalaryPortugal : IStrategy
    {
        private const string I_BASE_SALARY = "base_salary";
        private const string I_HOLIDAY_ALLOWANCE = "holiday_allowance";
        private const string I_CHRISTMAS_SUBSIDY = "Christmas_subsidy";
        private const string I_TWELFTHS = "twelfths";
        private const string O_LIQUID_SALARY = "liquid_salary";
        protected Country Country { get; set; }
        protected Region Region { get; set; }
        protected Parameters Param { get; set; }
        protected LiquidSalaryPortugalModel model { get; set; }

        public void SetStrategyParameters(Country aCountry, Region aRegion,
            IDictionary<string, object> aParametersDictionary)
        {
            Country = aCountry;
            Region = aRegion;
            Param = new Parameters(aParametersDictionary);

            model = new LiquidSalaryPortugalModel();
            LoadParamToModel();
        }

        public ResponseResult Execute()
        {
            var calculator = new LiquidSalaryPortugalCalculator(model);
            calculator.Calculate();


            IDictionary<string, object> returnParameters = new Dictionary<string, object>();

            returnParameters.Add(O_LIQUID_SALARY, model.LiquidSalary);


            var result = new ResponseResult {Parameters = returnParameters};
            return result;
        }

        private void LoadParamToModel()
        {
            model.BaseSalary = Param.GetDouble(I_BASE_SALARY);
            model.ChristmasSubsidy = Param.GetBool(I_HOLIDAY_ALLOWANCE);
            model.HolidaySubsidy = Param.GetBool(I_CHRISTMAS_SUBSIDY);
            model.Twelfths = Param.GeTwelfths(I_TWELFTHS);

            model.IRS = CalculateIRSFromSalary(model.BaseSalary);
            model.SS = CalculateSSFromSalary(model.BaseSalary);

            RedefineModel();
        }


        private double CalculateSSFromSalary(double aSalary)
        {
            return 0.11;
        }

        private double CalculateIRSFromSalary(double aSalary)
        {
            return 0.14;
        }

        protected virtual void RedefineModel() { }
    }
}