using eTaxSim.Models;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace eTaxSim.Adapter
{
    internal interface IAdapter
    {
        object OnAdapt();
    }
}
