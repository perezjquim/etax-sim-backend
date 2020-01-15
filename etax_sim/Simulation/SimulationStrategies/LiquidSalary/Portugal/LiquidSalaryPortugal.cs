using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util;
using System;
using System.Collections.Generic;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal
{
    internal class LiquidSalaryPortugal : IStrategy
    {
        private Country Country { get; set; }
        private Region Region { get; set; }
        private Parameters Param { get; set; }
        private LiquidSalaryPortugalModel model { get; set; }

        private const string I_BASE_SALARY = "base_salary";
        private const string I_HOLIDAY_ALLOWANCE = "holiday_allowance";
        private const string I_CHRISTMAS_SUBSIDY = "Christmas_subsidy";
        private const string I_TWELFTHS = "twelfths";
        private const string O_LIQUID_SALARY = "liquid_salary";

        public void SetStrategyParameters(Country aCountry, Region aRegion, IDictionary<string, object> aParametersDictionary)
        {
            this.Country = aCountry;
            this.Region = aRegion;
            this.Param = new Parameters(aParametersDictionary);

            this.model = new LiquidSalaryPortugalModel();
            LoadParamToModel();
        }

        public ResponseResult Execute()
        {




            LiquidSalaryPortugalCalculator calculator = new LiquidSalaryPortugalCalculator(model);
            calculator.Calculate();


            IDictionary<string, object> returnParameters = new Dictionary<string, object>();

            returnParameters.Add(O_LIQUID_SALARY, model.LiquidSalary);





            var result = new ResponseResult { Parameters = returnParameters };
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