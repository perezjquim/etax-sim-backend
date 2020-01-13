using System;
using System.Reflection;
using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTaxSim.Simulation.Strategy.Creation
{
    public class StrategyCreator
    {
        private readonly AppDbContext _context;

        public StrategyCreator(AppDbContext aContext)
        {
            this._context = aContext;
        }

        public IStrategy FactoryMethod(int aStrategy)
        {
            var strategyModel = _context.mStrategy.Find(aStrategy);

            var strategy = FindImplementClass(strategyModel.ImplementingClass);

            var a = strategyModel.ParamByStrategy;


            strategy.IsValidParameters();

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