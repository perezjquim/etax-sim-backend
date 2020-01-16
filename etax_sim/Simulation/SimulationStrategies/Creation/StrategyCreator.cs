using eTaxSim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTaxSim.Simulation.SimulationStrategies.Creation
{
    public class StrategyCreator
    {
        private readonly AppDbContext _context;

        private const string BASE_NAMESPACE = "eTaxSim.Simulation.SimulationStrategies";

        public StrategyCreator(AppDbContext aContext)
        {
            this._context = aContext;
        }

        public IStrategy FactoryMethod(Country aCountry, Region aRegion, Strategy aStrategy, IDictionary<string, object> aParametersDictionary)
        {

            var strategy = FindImplementClass(aStrategy.ImplementingClass, aCountry, aRegion);
            strategy.SetStrategyParameters(aCountry, aRegion, aParametersDictionary);

            return strategy;
        }
        // eTaxSim.Simulation.SimulationStrategies
        // eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal.Madeira.LiquidSalaryMadeira
        // eTaxSim.Simulation.SimulationStrategies.TaxReturn.Portugal.TaxReturnPortugal

        protected IStrategy FindImplementClass(string aClassName, Country aCountry, Region aRegion)
        {
            IStrategy myObject;

            var className = CreateClassName(aClassName, aRegion.Description);
            var strategyPath = CreateStrategyPath(aClassName, aCountry.Description, aRegion.Description);

            var completePath = CreateCompletePath(BASE_NAMESPACE, strategyPath, className);
            try
            {
                var type = Type.GetType(completePath);
                myObject = (IStrategy)Activator.CreateInstance(type);
            }
            catch (Exception)
            {
                try
                {
                    className = CreateClassName(aClassName, aCountry.Description);
                    strategyPath = CreateStrategyPath(aClassName, aCountry.Description, null);

                    completePath = CreateCompletePath(BASE_NAMESPACE, strategyPath, className);

                    var type = Type.GetType(completePath);
                    myObject = (IStrategy)Activator.CreateInstance(type);
                }
                catch (Exception e)
                {
                    var argEx = new ArgumentException("Class name not found", aClassName, e);
                    throw argEx;
                }
            }

            return myObject;
        }

        private string CreateCompletePath(string basePath, string strategyPath, string className)
        {
            var completePath = basePath + "." + strategyPath + "." + className;
            return completePath;
        }

        private string CreateStrategyPath(string aClassName, string aCountry, string aRegion)
        {
            StringBuilder strategyPath = new StringBuilder(aClassName);
            strategyPath.Append(".").Append(aCountry);

            if (!string.IsNullOrEmpty(aRegion))
            {
                strategyPath.Append(".").Append(aRegion);
            }
            return strategyPath.ToString();
        }

        private string CreateClassName(string aClassName, string aLocation)
        {
            return aClassName + aLocation;
        }
    }
}