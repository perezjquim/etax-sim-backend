using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace eTaxSim.Simulation
{
    public class Simulator
    {
        public Country Country { get; set; }
        public Region Region { get; set; }
        public Company Company { get; set; }
        public Sector Sector { get; set; }
        public Role Role { get; set; }
        public IStrategy Strategy { get; set; }
        public IDictionary<string, string> ParametersDictionary { get; set; }
        private readonly AppDbContext _context;

        public Simulator(AppDbContext context, Country aCountry, Region aRegion, Company aCompany, Sector aSector, Role aRole, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            this._context = context;
            this.Country = aCountry;
            this.Region = aRegion;
            this.Company = aCompany;
            this.Sector = aSector;
            this.Role = aRole;
            this.ParametersDictionary = aParametersDictionary;

            Strategy.SetStrategyParameters(Country, Region, aStrategy, ParametersDictionary);
        }

        public ResponseResult ExecuteSimulation()
        {
            var responseResult = Strategy.Execute();
            return responseResult;
        }
    }
}
