using eTaxSim.Models;
using eTaxSim.Simulation.Model;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace eTaxSim.Simulation
{
    public class Simulator
    {
        public Country Country { get; private set; }
        public Region Region { get; private set; }
        public Company Company { get; private set; }
        public Sector Sector { get; private set; }
        public Role Role { get; private set; }
        public IStrategy Strategy { get; private set; }
        public IDictionary<string, string> ParametersDictionary { get; private set; }
        private readonly AppDbContext _context;

        public Simulator(AppDbContext aContext)
        {
            this._context = aContext;
        }
        public Simulator(AppDbContext aContext, int aCountry, int aRegion, int aCompany, int aSector, int aRole, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            SetCountry(aCountry);
            SetRegion(aRegion);
            SetCompany(aCompany);
            SetSector(aSector);
            SetRole(aRole);
            this.ParametersDictionary = aParametersDictionary;
        }
        public Simulator(AppDbContext aContext, Country aCountry, Region aRegion, Company aCompany, Sector aSector, Role aRole, string aStrategy, IDictionary<string, string> aParametersDictionary)
        {
            this._context = aContext;
            this.Country = aCountry;
            this.Region = aRegion;
            this.Company = aCompany;
            this.Sector = aSector;
            this.Role = aRole;
            this.ParametersDictionary = aParametersDictionary;
        }

        public ResponseResult ExecuteSimulation()
        {
            var responseResult = Strategy.Execute();
            return responseResult;
        }

        public void SetCountry(int aCountry)
        {
            Country = _context.mCountries.Find(aCountry);
        }
        public void SetRegion(int aRegion)
        {
            Region = _context.mRegions.Find(aRegion);
        }
        public void SetCompany(int aCompany)
        {
            Company = _context.mCompanies.Find(aCompany);
        }
        public void SetSector(int aSector)
        {
            Sector = _context.mSectors.Find(aSector);
        }
        public void SetRole(int aRole)
        {
            Role = _context.mRoles.Find(aRole);
        }
    }
}
