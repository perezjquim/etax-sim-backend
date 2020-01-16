using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System.Collections.Generic;

namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal.Madeira
{
    internal class LiquidSalaryMadeira : LiquidSalaryPortugal
    {
        protected override void RedefineModel()
        {
            model.IRS = CalculateIRSFromSalary(model.BaseSalary);
        }

        private double CalculateIRSFromSalary(double aSalary)
        {
            return 0.11;
        }

    }
}