using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using etax_sim.Simulation.LiquidSalary.Strategy;
using etax_sim.Simulation.LiquidSalary.Strategy.Portugal;

namespace etax_sim.Simulation.LiquidSalary
{
    public sealed class MappingStrategy
    {
        public static MappingStrategy Mapping { get; } = new MappingStrategy();
        private IDictionary<string, IStrategy> countryMapping;

        private MappingStrategy()
        {
            countryMapping.Add("portugal", new StgPortugal());
        }

    }
}
