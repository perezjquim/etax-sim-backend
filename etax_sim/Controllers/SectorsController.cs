﻿using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTaxSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SectorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetmSectors()
        {
            return await _context.mSectors.Include("Companies").ToListAsync();
        }

        // GET: api/Sectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(int id)
        {
            var sector = await _context.mSectors.FindAsync(id);
            await _context.Entry(sector).Collection("Companies").LoadAsync();

            if (sector == null)
            {
                return NotFound();
            }

            return sector;
        }

        // PUT: api/Sectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, Sector sector)
        {
            if (id != sector.Id)
            {
                return BadRequest();
            }

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
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

        // POST: api/Sectors
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.mSectors.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.Id }, sector);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sector>> DeleteSector(int id)
        {
            var sector = await _context.mSectors.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.mSectors.Remove(sector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectorExists(int id)
        {
            return _context.mSectors.Any(e => e.Id == id);
        }
    }
}
