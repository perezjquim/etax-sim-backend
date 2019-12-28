using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTaxSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SimulationLogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SimulationLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimulationLog>>> GetmSimulationLogs()
        {
            return await _context.mSimulationLogs.ToListAsync();
        }

        // GET: api/SimulationLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SimulationLog>> GetSimulationLog(int id)
        {
            var simulationLog = await _context.mSimulationLogs.FindAsync(id);

            if (simulationLog == null)
            {
                return NotFound();
            }

            return simulationLog;
        }

        // PUT: api/SimulationLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSimulationLog(int id, SimulationLog simulationLog)
        {
            if (id != simulationLog.Id) return BadRequest();

            _context.Entry(simulationLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimulationLogExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/SimulationLogs
        [HttpPost]
        public async Task<ActionResult<SimulationLog>> PostSimulationLog(SimulationLog simulationLog)
        {
            _context.mSimulationLogs.Add(simulationLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSimulationLog", new {id = simulationLog.Id}, simulationLog);
        }

        // DELETE: api/SimulationLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SimulationLog>> DeleteSimulationLog(int id)
        {
            var simulationLog = await _context.mSimulationLogs.FindAsync(id);
            if (simulationLog == null) return NotFound();

            _context.mSimulationLogs.Remove(simulationLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SimulationLogExists(int id)
        {
            return _context.mSimulationLogs.Any(e => e.Id == id);
        }
    }
}