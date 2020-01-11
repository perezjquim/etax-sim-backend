using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace eTaxSim.Proxy
{
    public class StrategyProxy : IProxy
    {
        public object OnRequest(Dictionary<string, StringValues> aParameters, Strategy aStrategy, AppDbContext aContext)
        {
            //verify strategy params name and value
            var strategyParams = this.GetStrategyParams(aStrategy, aContext);
            var paramsCheck = this.VerifyStrategyParams(strategyParams.Value.ParamByStrategy, aContext, aParameters);
            if(paramsCheck == true)
            {
                return strategyParams;
            }
            return null;
            //return paramsCheck;
        }

        public ActionResult<Strategy> GetStrategyParams(Strategy aStrategy, AppDbContext aContext)
        {
            /*var strategy = aContext.mStrategy.Find(aStrategyId);
            if (strategy == null)
            {
                return null;
            }*/
            aContext.Entry(aStrategy).Collection("ParamByStrategy").Load();
            foreach(ParamByStrategy param in aStrategy.ParamByStrategy)
            {
                aContext.Entry(param).Reference("StrategyParamRule").Load();
            }
            //aContext.Entry(strategy).Collection("ParamByStrategy.StrategyParamRule").Load();
            return aStrategy;
        }

        public bool VerifyStrategyParams(ICollection<ParamByStrategy> aStrategyParams, AppDbContext aContext, Dictionary<string, StringValues> aParameters)
        {
            var a = aStrategyParams;
            //loop at aStrategyParams
            var paramsEnum = aStrategyParams.GetEnumerator();
            while(paramsEnum.MoveNext())
            {
                var param = paramsEnum.Current;
                if(aParameters.ContainsKey(param.ParamName))
                {
                    var rule = param.StrategyParamRule;
                    if (aParameters.TryGetValue(param.ParamName, out StringValues values))
                    {

                       var valuesArray = values.ToArray();
                       if (valuesArray.Length > 0)
                       {
                          var inputValue = valuesArray[0];
                          var result = this.VerifyRule(rule.MinValue, rule.MaxValue, inputValue);
                          if(result == false)
                          {
                                return false;
                          }
                       }
                    }
                    else
                    {
                       return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerifyRule(double? aMinValue, double? aMaxValue, string aInputValue)
        {
            var inputValue = Convert.ToDouble(aInputValue);
            if (aMaxValue != null && aMinValue != null)
            {
                if(inputValue >= aMinValue && inputValue <= aMaxValue)
                {
                    return true;
                }
                return false;
            }
            else if(aMaxValue == null && aMinValue != null)
            {
                if(inputValue >= aMinValue)
                {
                    return true;
                }
                return false;
            }
            else if(aMaxValue != null && aMinValue == null)
            {
                if(inputValue <= aMaxValue)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
