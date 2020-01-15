using eTaxSim.Models;
using eTaxSim.Simulation;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace eTaxSim.Adapter
{
    public class SimulAdapter : IAdapter
    {
        public Simulator OnAdapt(AppDbContext aContext, Strategy aStrategy, int aCountryId, int aRegionId, Dictionary<string, StringValues> aInputParameters)
        {
            //get country
            var country = aContext.mCountries.Find(aCountryId);
            var region = aContext.mRegions.Find(aRegionId);
            var inputParamsResult = this.ConvertDictionary(aInputParameters);
            Simulator simul = new Simulator(aContext, country, region, null, null, null, aStrategy, inputParamsResult);


            return simul;
        }

        public Dictionary<string, object> ConvertDictionary(Dictionary<string, StringValues> aInputParameters)
        {
            Dictionary<string, object> inputParamsResult = new Dictionary<string, object>();
            foreach (KeyValuePair<string, StringValues> param in aInputParameters)
            {
                var value = param.Value.ToArray()[0];
                //KeyValuePair<string, string> paramater = new KeyValuePair<string, string>(param.Key,value);
                inputParamsResult.Add(param.Key, value);
            }
            return inputParamsResult;
        }
    }
}
