using eTaxSim.Models;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace eTaxSim.Proxy
{
    internal interface IProxy
    {
        object OnRequest(Dictionary<string, StringValues> aParameters, Strategy aStrategy, AppDbContext aContext, int aCountryId, int aRegionId);
    }
}
