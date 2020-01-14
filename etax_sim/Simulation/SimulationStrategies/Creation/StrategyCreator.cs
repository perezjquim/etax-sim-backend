using eTaxSim.Models;
using System;
using System.Collections.Generic;

namespace eTaxSim.Simulation.SimulationStrategies.Creation
{
    public class StrategyCreator
    {
        private readonly AppDbContext _context;

        public StrategyCreator(AppDbContext aContext)
        {
            this._context = aContext;
        }

        public IStrategy FactoryMethod(Country aCountry, Region aRegion, Strategy aStrategy, IDictionary<string, object> aParametersDictionary)
        {
            var strategy = FindImplementClass(aStrategy.ImplementingClass);
            strategy.SetStrategyParameters(aCountry, aRegion, aParametersDictionary);

            return strategy;
        }

        protected IStrategy FindImplementClass(string aClassName)
        {
            IStrategy myObject;
            try
            {
                var type = Type.GetType(aClassName);
                myObject = (IStrategy)Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                var argEx = new ArgumentException("Class name not found", aClassName, e);
                throw argEx;
            }

            return myObject;
        }
    }
}