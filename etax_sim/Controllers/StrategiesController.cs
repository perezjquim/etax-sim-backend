﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTaxSim.Models;
using System.IO;
using eTaxSim.Proxy;
using Microsoft.Extensions.Primitives;

namespace eTaxSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StrategiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Strategies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Strategy>>> GetmStrategy()
        {
            return await _context.mStrategy.ToListAsync();
        }

        // GET: api/Strategies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Strategy>> GetStrategy(int id)
        {
            var strategy = await _context.mStrategy.FindAsync(id);

            if (strategy == null)
            {
                return NotFound();
            }

            return strategy;
        }

        // PUT: api/Strategies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrategy(int id, Strategy strategy)
        {
            if (id != strategy.Id)
            {
                return BadRequest();
            }

            _context.Entry(strategy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrategyExists(id))
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

        // POST: api/Strategies
        [HttpPost]
        public async Task<ActionResult<Strategy>> PostStrategy(Strategy strategy)
        {
            _context.mStrategy.Add(strategy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrategy", new { id = strategy.Id }, strategy);
        }

        // POST: api/Strategies
        [HttpPost("{id}/{countryId}/{regionId}/evaluate")]
        public ActionResult<Strategy> PostStrategySimul(int id, int countryId, int regionId, IFormCollection form)
        {
            //var i = input;
            /*using (var reader = new StreamReader(Request.Form))
            {
                var body = reader.ReadToEnd();
                var first = body.Trim();
                // Do something
            }*/
            //form.TryGetValue("name",out var item);
            var strategy = _context.mStrategy.Find(id);
            if (strategy == null)
            {
                return NotFound();
            }
            var body = form.ToDictionary(k => k.Key, v => v.Value);
            //var body = form.ToList();
            StrategyProxy proxy = new StrategyProxy();
            var strategyResult = proxy.OnRequest(body, strategy, _context);
            var properties = strategyResult.GetType().GetProperties();
            var resultType = properties[1].GetValue(strategyResult, null);
            var msg = properties[2].GetValue(strategyResult, null);
            //if (strategyResult != null)
            if (resultType.Equals("S"))
            {
                SimulAdapter simulAdapter = new SimulAdapter();
                var simulInput = simulAdapter.OnAdapt(_context, strategy, countryId, regionId, body);
                //simulInput.ExecuteSimulation();
                return Ok(new { type = resultType, msg = msg });
            }
            //enviar mensagem de erro.
            return BadRequest(new { type = resultType, msg = msg });
            //return strategyResult;
        }

        // DELETE: api/Strategies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Strategy>> DeleteStrategy(int id)
        {
            var strategy = await _context.mStrategy.FindAsync(id);
            if (strategy == null)
            {
                return NotFound();
            }

            _context.mStrategy.Remove(strategy);
            await _context.SaveChangesAsync();

            return strategy;
        }

        private bool StrategyExists(int id)
        {
            return _context.mStrategy.Any(e => e.Id == id);
        }
    }
}
