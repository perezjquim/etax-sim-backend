﻿using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System.Collections.Generic;

namespace eTaxSim.Simulation
{
    public interface IStrategy
    {
        ResponseResult Execute();

        void SetStrategyParameters(Country aCountry, Region aRegion, IDictionary<string, object> aParametersDictionary);
    }
}