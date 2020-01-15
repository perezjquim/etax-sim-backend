using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTaxSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyByCountriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StrategyByCountriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StrategyByCountries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StrategyByCountry>>> GetmStrategyByCountry()
        {
            return await _context.mStrategyByCountry.ToListAsync();
        }

        // GET: api/StrategyByCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StrategyByCountry>> GetStrategyByCountry(int id)
        {
            var strategyByCountry = await _context.mStrategyByCountry.FindAsync(id);

            if (strategyByCountry == null)
            {
                return NotFound();
            }

            return strategyByCountry;
        }

        // GET: api/StrategyByCountries/country/5/6
        [HttpGet("country/region/{countryId}/{regionId}")]
        public async Task<ActionResult<IEnumerable<StrategyByCountry>>> GetStrategyByCountryId(int countryId, int regionId)
        {
            //get all strategies that not have exceptions
            /*var countryStrategies = await _context.mStrategyByCountry.Where(s => s.CountryId == countryId).Include("Country").Include("Strategy").
                Where(s => !_context.mStrategyByCountryByRegion.Where(sRegion => sRegion.RegionId == regionId && sRegion.ParentStrategyId == s.StrategyId).
                Select(sr => sr.CountryId).Contains(s.CountryId)).ToListAsync();*/

            var countryStrategies = await _context.mStrategyByCountry.Where(s => s.CountryId == countryId).Include("Country").Include("Strategy").ToListAsync();
            //.Include("StrategyByCountryByRegion").Include("StrategyByCountryByRegion.Strategy").ToListAsync();
            List<StrategyByCountry> listResult = new List<StrategyByCountry>();
            for (var i = 0; i < countryStrategies.Count; i++)
            {
                //Check if have exception to region
                var regionExeption = _context.mStrategyByCountryByRegion.Where(r => r.CountryId == countryId && r.RegionId == regionId && r.StrategyByCountryId == countryStrategies[i].Id).Include("Strategy").FirstOrDefault();
                if (regionExeption != null)
                {
                    countryStrategies[i].StrategyByCountryByRegion.Add(regionExeption);
                }
                listResult.Add(countryStrategies[i]);
                /*if (countryStrategies[i].StrategyByCountryByRegion.Count == 0 || countryStrategies[i].StrategyByCountryByRegion.First().RegionId == regionId)
                {
                    listResult.Add(countryStrategies[i]);
                }*/
            }
            /*Select(s => new
            {
                CountryStrategy = s,
                RegionStrategy = s.StrategyByCountryByRegion.Where(r => r.RegionId == regionId)
            }).ToListAsync();*/
            //get exceptions for selected region
            /*var exceptions = await _context.mStrategyByCountryByRegion.Where(s => s.CountryId == countryId && s.RegionId == regionId).Include("Country").
                Include("Strategy").ToListAsync();/*
            /*dynamic result = new JObject();
            result.countryStrategies = new JArray(countryStrategies);
            result.exceptions = new JArray(exceptions);
            return result;*/
            return listResult;
        }

        // PUT: api/StrategyByCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrategyByCountry(int id, StrategyByCountry strategyByCountry)
        {
            if (id != strategyByCountry.Id)
            {
                return BadRequest();
            }

            _context.Entry(strategyByCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrategyByCountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StrategyByCountries
        [HttpPost]
        public async Task<ActionResult<StrategyByCountry>> PostStrategyByCountry(StrategyByCountry strategyByCountry)
        {
            _context.mStrategyByCountry.Add(strategyByCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrategyByCountry", new { id = strategyByCountry.Id }, strategyByCountry);
        }

        // DELETE: api/StrategyByCountries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StrategyByCountry>> DeleteStrategyByCountry(int id)
        {
            var strategyByCountry = await _context.mStrategyByCountry.FindAsync(id);
            if (strategyByCountry == null)
            {
                return NotFound();
            }

            _context.mStrategyByCountry.Remove(strategyByCountry);
            await _context.SaveChangesAsync();

            return strategyByCountry;
        }

        private bool StrategyByCountryExists(int id)
        {
            return _context.mStrategyByCountry.Any(e => e.Id == id);
        }
    }
}
