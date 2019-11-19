using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using etax_sim.Models;

namespace etax_sim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/countries
        [HttpGet]
        public ActionResult<List<Country>> Get()
        {
            var list = _context.countries.ToList();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            var country = _context.countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST api/countries
        [HttpPost]
        public ActionResult<Country> Post(Country country)
        {
            _context.countries.Add(country);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = country.Id }, country);
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public ActionResult<Country> Put(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public ActionResult<Country> Delete(int id)        
        {
            var country = _context.countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            _context.countries.Remove(country);
            _context.SaveChanges();

            return Ok(country);
        }
    }
}
