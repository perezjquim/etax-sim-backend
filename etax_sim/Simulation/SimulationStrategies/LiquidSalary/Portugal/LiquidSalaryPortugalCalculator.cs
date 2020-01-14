using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal
{
    internal class LiquidSalaryPortugalCalculator
    {
        public LiquidSalaryPortugalModel Model { get; set; }

        public LiquidSalaryPortugalCalculator(LiquidSalaryPortugalModel aModel)
        {
            this.Model = aModel;
        }

        public void Calculate()
        {
            Model.BaseTwelfthsChristmasSubsidy = CalculateSubsidy(Model.ChristmasSubsidy, Model.Twelfths, Model.BaseSalary);
            Model.BaseTwelfthsHolidaySubsidy = CalculateSubsidy(Model.HolidaySubsidy, Model.Twelfths, Model.BaseSalary);

            Model.LiquidSalary = ApplyTaxes(Model.BaseSalary);
            Model.LiquidTwelfthsChristmasSubsidy = ApplyTaxes(Model.BaseTwelfthsChristmasSubsidy);
            Model.LiquidTwelfthsHolidaySubsidy = ApplyTaxes(Model.BaseTwelfthsHolidaySubsidy);
        }

        private static double CalculateSubsidy(bool aSubsidy, Twelfths aTwelfths, double aSalary)
        {
            if (aSubsidy)
            {
                switch (aTwelfths)
                {
                    case Twelfths.Percent0:
                        return 0;
                    case Twelfths.Percent50:
                        return (aSalary / 2) / 12;
                    case Twelfths.Percent100:
                        return aSalary / 12;
                }
            }

            return 0;
        }

        private double ApplyTaxes(double aValue)
        {
            double result = aValue;
            double irsDeduct = ApplyTax(aValue, Model.IRS);
            double ssDeduct = ApplyTax(aValue, Model.SS);

            result = result - irsDeduct - ssDeduct;
            return result;
        }

        private double ApplyTax(double aSalary, double aTaxPercent)
        {
            double result = aSalary * aTaxPercent;
            return result;
        }
    }
}