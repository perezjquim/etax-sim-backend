namespace eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Spain
{
    internal class LiquidSalarySpainCalculator
    {
        public LiquidSalarySpainCalculator(LiquidSalarySpainModel aModel)
        {
            Model = aModel;
        }

        public LiquidSalarySpainModel Model { get; set; }

        public void Calculate()
        {
            var result = Model.BaseSalary * Model.NumberSalary / 12;
            Model.LiquidSalary = result;
        }
    }
}