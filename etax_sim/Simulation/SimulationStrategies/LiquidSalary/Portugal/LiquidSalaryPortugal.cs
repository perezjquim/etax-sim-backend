using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using eTaxSim.Util.Map;
using System.Collections.Generic;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal
{
    internal class LiquidSalaryPortugal : IStrategy
    {
        private Country Country { get; set; }
        private Region Region { get; set; }
        private Parameters Param { get; set; }

        private const string BASE_SALARY = "base_salary";
        private const string HOLIDAY_ALLOWANCE = "holiday_allowance";
        private const string CHRISTMAS_SUBSIDY = "Christmas_subsidy";
        private const string TWELFTHS = "twelfths";
        private const string TWELFTHS_WHOLE = "whole";
        private const string TWELFTHS_50 = "50percent";
        private const string TWELFTHS_100 = "100percent";

        public ResponseResult Execute()
        {
            var result = new ResponseResult();






            return result;
        }

        public void SetStrategyParameters(Country aCountry, Region aRegion, IDictionary<string, object> aParametersDictionary)
        {
            this.Country = aCountry;
            this.Region = aRegion;
            this.Param = new Parameters(aParametersDictionary);
        }

        private double CalculateLiquidSalary()
        {
            var salary = Param.GetDouble(BASE_SALARY);

            var ss = getFromSomewhereSS();
            var irs = getFromSomewhereIRS();

            var liquidSalary = salary - (salary * ss) - (salary * irs);


        }

        private double CalculateTwelfths(double aSalary)
        {
            var holiday = Param.GetBool(HOLIDAY_ALLOWANCE);
            var christmas = Param.GetBool(CHRISTMAS_SUBSIDY);
            var twelfths = Param.GetString(TWELFTHS);

            var holidayValue = CalculateSubsidy(holiday, twelfths, aSalary);
            var christmasValue = CalculateSubsidy(christmas, twelfths, aSalary);

            return holidayValue + christmasValue;
        }

        private double CalculateSubsidy(bool aSubsidy, string aTwelfths, double aSalary)
        {
            if (aSubsidy)
            {
                switch (aTwelfths)
                {
                    case TWELFTHS_WHOLE:
                        return 0;
                    case TWELFTHS_50:
                        return (aSalary / 2) / 12;
                    case TWELFTHS_100:
                        return aSalary / 12;
                }
            }

            return 0;
        }

        private double getFromSomewhereSS()
        {
            // TODO
            return 11;
        }
        private double getFromSomewhereIRS()
        {
            // TODO
            return 14.4;
        }
    }
}