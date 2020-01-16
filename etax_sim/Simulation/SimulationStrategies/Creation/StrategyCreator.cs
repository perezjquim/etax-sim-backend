using eTaxSim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTaxSim.Simulation.SimulationStrategies.Creation
{
    public class StrategyCreator
    {
        private readonly AppDbContext _context;
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BASE_NAMESPACE = "eTaxSim.Simulation.SimulationStrategies";

        public StrategyCreator(AppDbContext aContext)
        {
            this._context = aContext;
        }

        public IStrategy FactoryMethod(Country aCountry, Region aRegion, Strategy aStrategy, IDictionary<string, object> aParametersDictionary)
        {
            Log.Info("This is just to inform you");
            Log.Warn("Something you should consider. better check this out!!!");
            Log.Error("oops!!something wrong");
            Log.Fatal("you are dead, man!!!");

            //var strategy = FindImplementClass(aStrategy.ImplementingClass);
            //strategy.SetStrategyParameters(aCountry, aRegion, aParametersDictionary);

            //return strategy;
            return null;
        }
        // eTaxSim.Simulation.SimulationStrategies
        // eTaxSim.Simulation.SimulationStrategies.LiquidSalary.Portugal.Madeira.LiquidSalaryMadeira
        // eTaxSim.Simulation.SimulationStrategies.TaxReturn.Portugal.TaxReturnPortugal

        protected IStrategy FindImplementClass(string aClassName, Country aCountry, Region aRegion)
        {
            IStrategy myObject;

            var className = CreateClassName(aClassName, aRegion.Name);
            var strategyPath = CreateStrategyPath(aCountry.Name, aRegion.Name);

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
                    className = CreateClassName(aClassName, aCountry.Name);
                    strategyPath = CreateStrategyPath(aCountry.Name, null);

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

        private string CreateStrategyPath(string aCountry, string aRegion)
        {
            StringBuilder strategyPath = new StringBuilder(aCountry);
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