﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etax_sim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyByCountryByRegionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StrategyByCountryByRegionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StrategyByCountryByRegions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StrategyByCountryByRegion>>> GetmStrategyByCountryByRegion()
        {
            return await _context.mStrategyByCountryByRegion.ToListAsync();
        }

        // GET: api/StrategyByCountryByRegions/country/region/5/6
        [HttpGet("country/region/{countryId}/{regionId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetmStrategyByCountryByRegionId(int countryId,
            int regionId)
        {
            var exceptions = await _context.mStrategyByCountryByRegion.Where(s => s.CountryId == countryId)
                .Where(s => s.RegionId == regionId).Include("Strategy").ToListAsync();
            if (exceptions.Count < 1)
                //get general strategies
                return await _context.mStrategyByCountry.Where(s => s.CountryId == countryId).Include("Strategy")
                    .ToListAsync();
            return exceptions;
        }

        // GET: api/StrategyByCountryByRegions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StrategyByCountryByRegion>> GetStrategyByCountryByRegion(int id)
        {
            var strategyByCountryByRegion = await _context.mStrategyByCountryByRegion.FindAsync(id);

            if (strategyByCountryByRegion == null) return NotFound();

            return strategyByCountryByRegion;
        }

        // PUT: api/StrategyByCountryByRegions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrategyByCountryByRegion(int id,
            StrategyByCountryByRegion strategyByCountryByRegion)
        {
            if (id != strategyByCountryByRegion.Id) return BadRequest();

            _context.Entry(strategyByCountryByRegion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrategyByCountryByRegionExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/StrategyByCountryByRegions
        [HttpPost]
        public async Task<ActionResult<StrategyByCountryByRegion>> PostStrategyByCountryByRegion(
            StrategyByCountryByRegion strategyByCountryByRegion)
        {
            _context.mStrategyByCountryByRegion.Add(strategyByCountryByRegion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrategyByCountryByRegion", new {id = strategyByCountryByRegion.Id},
                strategyByCountryByRegion);
        }

        // DELETE: api/StrategyByCountryByRegions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StrategyByCountryByRegion>> DeleteStrategyByCountryByRegion(int id)
        {
            var strategyByCountryByRegion = await _context.mStrategyByCountryByRegion.FindAsync(id);
            if (strategyByCountryByRegion == null) return NotFound();

            _context.mStrategyByCountryByRegion.Remove(strategyByCountryByRegion);
            await _context.SaveChangesAsync();

            return strategyByCountryByRegion;
        }

        private bool StrategyByCountryByRegionExists(int id)
        {
            return _context.mStrategyByCountryByRegion.Any(e => e.Id == id);
        }
    }
}