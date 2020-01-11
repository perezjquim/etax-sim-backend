using eTaxSim.Models;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace eTaxSim.Proxy
{
    internal interface IProxy
    {
        bool OnRequest(Dictionary<string, StringValues> aParameters, int aStrategyId, AppDbContext aContext);
    }
}
