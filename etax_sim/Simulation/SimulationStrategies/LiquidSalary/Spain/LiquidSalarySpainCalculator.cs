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