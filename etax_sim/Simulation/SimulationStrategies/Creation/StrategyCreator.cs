﻿using eTaxSim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTaxSim.Simulation.SimulationStrategies.Creation
{
    public class StrategyCreator
    {
        private readonly AppDbContext _context;

        private const string BASE_NAMESPACE = "eTaxSim.Simulation.SimulationStrategies";
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                    logger.Warn("There is no regional strategy for this simulation");

                    className = CreateClassName(aClassName, aCountry.Description);
                    strategyPath = CreateStrategyPath(aClassName, aCountry.Description, null);

                    completePath = CreateCompletePath(BASE_NAMESPACE, strategyPath, className);

                    var type = Type.GetType(completePath);
                    myObject = (IStrategy)Activator.CreateInstance(type);

                }
                catch (Exception e)
                {
                    var argEx = new ArgumentException("Class name not found", aClassName, e);
                    logger.Error("There is no class with name " + aClassName, e);
                    throw argEx;
                }
            }

            logger.Info("Implementing class: " + completePath);

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