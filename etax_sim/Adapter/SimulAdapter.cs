using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation;
using Microsoft.Extensions.Primitives;

namespace eTaxSim.Adapter
{
    public class SimulAdapter : IAdapter
    {
        public Simulator OnAdapt(AppDbContext aContext, Strategy aStrategy, int aCountryId, int aRegionId,
            Dictionary<string, StringValues> aInputParameters)
        {
            //get country
            var country = aContext.mCountries.Find(aCountryId);
            var region = aContext.mRegions.Find(aRegionId);
            var inputParamsResult = ConvertDictionary(aInputParameters);
            var simul = new Simulator(aContext, country, region, null, null, null, aStrategy, inputParamsResult);
            
            return simul;
        }

        public Dictionary<string, object> ConvertDictionary(Dictionary<string, StringValues> aInputParameters)
        {
            var inputParamsResult = new Dictionary<string, object>();
            foreach (var param in aInputParameters)
            {
                var value = param.Value.ToArray()[0];
                inputParamsResult.Add(param.Key, value);
            }

            return inputParamsResult;
        }
    }
}