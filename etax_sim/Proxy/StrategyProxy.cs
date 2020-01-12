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
            var properties = paramsCheck.GetType().GetProperties();
            //if(paramsCheck == true)
            var type = properties[0].GetValue(paramsCheck, null);
            var msg = properties[1].GetValue(paramsCheck, null);
            if (type.Equals("S"))
            {
                return new { strategy = strategyParams, type = type, msg = msg };
            }
            return new { strategy = (object)null, type = type, msg = msg };
            //return null;
        }

        public ActionResult<Strategy> GetStrategyParams(Strategy aStrategy, AppDbContext aContext)
        {
            /*var strategy = aContext.mStrategy.Find(aStrategyId);
            if (strategy == null)
            {
                return null;
            }*/
            aContext.Entry(aStrategy).Collection("ParamByStrategy").Load();
            foreach (ParamByStrategy param in aStrategy.ParamByStrategy)
            {
                aContext.Entry(param).Reference("StrategyParamRule").Load();
            }
            foreach (ParamByStrategy param in aStrategy.ParamByStrategy)
            {
                aContext.Entry(param).Collection("ParamAllowedValue").Load();
            }
            //aContext.Entry(strategy).Collection("ParamByStrategy.StrategyParamRule").Load();
            return aStrategy;
        }

        public object VerifyStrategyParams(ICollection<ParamByStrategy> aStrategyParams, AppDbContext aContext, Dictionary<string, StringValues> aParameters)
        {
            var a = aStrategyParams;
            //loop at aStrategyParams
            var paramsEnum = aStrategyParams.GetEnumerator();
            while (paramsEnum.MoveNext())
            {
                var param = paramsEnum.Current;
                if (aParameters.ContainsKey(param.ParamName))
                {
                    //var rule = param.StrategyParamRule;
                    if (aParameters.TryGetValue(param.ParamName, out StringValues values))
                    {

                        var valuesArray = values.ToArray();
                        if (valuesArray.Length > 0)
                        {
                            var inputValue = valuesArray[0];
                            var rule = param.StrategyParamRule;
                            if (rule != null)
                            {
                                var result = this.VerifyRule(rule.MinValue, rule.MaxValue, inputValue);
                                if (result == false)
                                {
                                    //return false;
                                    return new { type = "E", msg = "InvalidParameterValue" };
                                }
                            }
                            else
                            {
                                //not have rule, verify allowed params
                            }
                        }
                    }
                    else
                    {
                        //return false;
                        return new { type = "E", msg = "InvalidParameterValue" };
                    }
                }
                else
                {
                    //return false;
                    return new { type = "E", msg = "MissingParameters" };
                }
            }
            //return true;
            return new { type = "S", msg = "ValidParameters" };
        }

        public bool VerifyRule(double? aMinValue, double? aMaxValue, string aInputValue)
        {
            var inputValue = Convert.ToDouble(aInputValue);
            if (aMaxValue != null && aMinValue != null)
            {
                if (inputValue >= aMinValue && inputValue <= aMaxValue)
                {
                    return true;
                }
                return false;
            }
            else if (aMaxValue == null && aMinValue != null)
            {
                if (inputValue >= aMinValue)
                {
                    return true;
                }
                return false;
            }
            else if (aMaxValue != null && aMinValue == null)
            {
                if (inputValue <= aMaxValue)
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

        public bool verifyAllowedValues()
        {
            return true;
        }
    }
}
