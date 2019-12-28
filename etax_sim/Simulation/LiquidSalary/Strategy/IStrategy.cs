using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etax_sim.Simulation.LiquidSalary.Strategy
{
    public interface IStrategy
    {

        double Execute(IDictionary<string, string> parametersDictionary);

    }
}
