namespace eTaxSim.Simulation.LiquidSalary.Strategy
{
    public interface IStrategy
    {

        ResponseResult Execute();

        bool ValidateStrategyParam();

    }
}
