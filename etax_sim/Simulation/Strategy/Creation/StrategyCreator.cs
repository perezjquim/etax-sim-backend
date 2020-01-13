using System;

namespace eTaxSim.Simulation.Strategy.Creation
{
    public class StrategyCreator
    {

        public IStrategy FactoryMethod(string aClassName)
        {
            var strategy = FindImplementClass(aClassName);

            //strategy.SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary);

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
                ArgumentException argEx = new ArgumentException("Class name not found", className, e);
                throw argEx;
            }

            return myObject;
        }
    }
}