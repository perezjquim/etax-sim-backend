using System.Collections.Generic;
using eTaxSim.Models;
using eTaxSim.Simulation;
using Microsoft.Extensions.Primitives;

namespace eTaxSim.Adapter
{
    internal interface IAdapter
    {
        Simulator OnAdapt(AppDbContext aContext, Strategy aStrategy, int aCountryId, int aRegionId,
            Dictionary<string, StringValues> aInputParameters);
    }
}