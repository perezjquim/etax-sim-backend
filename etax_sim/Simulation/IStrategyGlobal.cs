﻿using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System.Collections.Generic;

namespace eTaxSim.Simulation
{
    public interface IStrategyGlobal
    {
        ResponseResult Execute();

        bool IsValidParameters();

        void SetStrategyParameters(Country aCountry, Region aRegion, string aStrategy, IDictionary<string, string> aParametersDictionary);
    }
}
