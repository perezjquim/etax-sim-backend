namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    internal interface IStrategy
    { 
        ResponseResult Execute();

        bool ValidateStrategyParam();
    }
}
