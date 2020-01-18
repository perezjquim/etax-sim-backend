using System.Collections.Generic;
using eTaxSim.Models;
using Microsoft.Extensions.Primitives;

namespace eTaxSim.Proxy
{
    internal interface IProxy
    {
        object OnRequest(Dictionary<string, StringValues> aParameters, Strategy aStrategy, AppDbContext aContext,
            int aCountryId, int aRegionId);
    }
}