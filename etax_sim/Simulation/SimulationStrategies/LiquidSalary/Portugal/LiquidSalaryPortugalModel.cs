using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal
{
    internal class LiquidSalaryPortugalModel
    {
        public double BaseSalary { get; set; }
        public double BaseTwelfthsHolidaySubsidy { get; set; }
        public double BaseTwelfthsChristmasSubsidy { get; set; }

        public Twelfths Twelfths { get; set; }
        public bool HolidaySubsidy { get; set; }
        public bool ChristmasSubsidy { get; set; }
        
        public double IRS { get; set; }
        public double SS { get; set; }

        public double LiquidSalary { get; set; }
        public double LiquidTwelfthsHolidaySubsidy { get; set; }
        public double LiquidTwelfthsChristmasSubsidy { get; set; }


    }
}