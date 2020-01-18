﻿using eTaxSim.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eTaxSim.Proxy
{
    public class StrategyProxy : IProxy
    {
        public object OnRequest(Dictionary<string, StringValues> aParameters, Strategy aStrategy, AppDbContext aContext, int aCountryId, int aRegionId)
        {
            //verify strategy params name and value
            var strategyParams = this.CheckIfHaveParent(aStrategy.Id, aCountryId, aRegionId, aContext);
            var paramsCheck = this.VerifyStrategyParams(strategyParams, aContext, aParameters);

            var properties = paramsCheck.GetType().GetProperties();

            var type = properties[0].GetValue(paramsCheck, null);
            var msg = properties[1].GetValue(paramsCheck, null);
            if (type.Equals("S"))
            {
                return new { strategy = strategyParams, type = type, msg = msg };
            }
            return new { strategy = (object)null, type = type, msg = msg };
        }

        public ICollection<ParamByStrategy> CheckIfHaveParent(int aStrategyId, int aCountryId, int aRegionId, AppDbContext aContext)
        {
            var childStrategy = aContext.mStrategyByCountryByRegion.Where(s => s.StrategyId == aStrategyId && s.CountryId == aCountryId && s.RegionId == aRegionId).
                FirstOrDefault();
            ICollection<ParamByStrategy> childParameters = null;
            if (childStrategy != null)
            {
                aContext.Entry(childStrategy).Reference("Strategy").Load();
                aContext.Entry(childStrategy.Strategy).Collection("ParamByStrategy").Load();
                childParameters = this.GetParamsData(childStrategy.Strategy.ParamByStrategy, aContext);
            }
            //get parent strategy
            int parentStrategyId;
            if (childStrategy != null)
            {
                aContext.Entry(childStrategy).Reference("StrategyByCountry").Load();
                parentStrategyId = childStrategy.StrategyByCountry.StrategyId;
            }
            else
            {
                parentStrategyId = aStrategyId;
            }

            var parentStrategy = aContext.mStrategyByCountry.Where(s => s.StrategyId == parentStrategyId && s.CountryId == aCountryId).FirstOrDefault();
            ICollection<ParamByStrategy> parentParameters = null;
            if (parentStrategy != null)
            {
                aContext.Entry(parentStrategy).Reference("Strategy").Load();
                aContext.Entry(parentStrategy.Strategy).Collection("ParamByStrategy").Load();
                parentParameters = this.GetParamsData(parentStrategy.Strategy.ParamByStrategy, aContext);

            }

            var parameters = parentParameters;
            if (childParameters != null)
            {
                foreach (ParamByStrategy param in childParameters)
                {
                    parameters.Add(param);
                }
            }

            return parameters;
        }

        public ICollection<ParamByStrategy> GetParamsData(ICollection<ParamByStrategy> aParameters, AppDbContext aContext)
        {
            ICollection<ParamByStrategy> paramsAux = aParameters;
            foreach (ParamByStrategy paramByStrategy in aParameters.ToList())
            {
                if (paramByStrategy.IsInput == true)
                {
                    aContext.Entry(paramByStrategy).Reference("StrategyParamRule").Load();
                }
                else
                {
                    paramsAux.Remove(paramByStrategy);
                }
            }
            foreach (ParamByStrategy paramByStrategy in paramsAux)
            {
                aContext.Entry(paramByStrategy).Collection("ParamAllowedValue").Load();
                foreach (ParamAllowedValue paramAllowedValue in paramByStrategy.ParamAllowedValue)
                {
                    aContext.Entry(paramAllowedValue).Reference("RuleAllowedValue").Load();
                }
            }
            return paramsAux;
        }

        public object VerifyStrategyParams(ICollection<ParamByStrategy> aStrategyParams, AppDbContext aContext, Dictionary<string, StringValues> aParameters)
        {
            //loop at aStrategyParams
            if (aStrategyParams == null)
            {
                return new { type = "E", msg = "NoParamsConfigured" };
            }
            var paramsEnum = aStrategyParams.GetEnumerator();
            while (paramsEnum.MoveNext())
            {
                var param = paramsEnum.Current;
                if (aParameters.ContainsKey(param.ParamName))
                {
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
                                    return new { type = "E", msg = "InvalidParameterValue" };
                                }
                            }
                            else//not have rule, verify allowed params
                            {
                                var paramEnumValues = param.ParamAllowedValue;
                                var result = this.verifyAllowedValues(paramEnumValues, inputValue);
                                if (result == false)
                                {
                                    return new { type = "E", msg = "InvalidParameterValue" };
                                }
                            }
                        }
                    }
                    else
                    {
                        return new { type = "E", msg = "InvalidParameterValue" };
                    }
                }
                else
                {
                    return new { type = "E", msg = "MissingParameters" };
                }
            }
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

        public bool verifyAllowedValues(ICollection<ParamAllowedValue> aAllowedValues, string aInputValue)
        {
            foreach (ParamAllowedValue value in aAllowedValues)
            {
                if (value.RuleAllowedValue.Value == aInputValue)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
