using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal;
using eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Util;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Spain
{
    internal class LiquidSalarySpainCalculator
    {
        public LiquidSalarySpainModel Model { get; set; }

        public LiquidSalarySpainCalculator(LiquidSalarySpainModel aModel)
        {
            this.Model = aModel;
        }

        public void Calculate()
        {
            double result = (Model.BaseSalary * Model.NumberSalary) / 12;
            Model.LiquidSalary = result;
        }
    }
}