using System.Collections.Generic;
using System.Linq;
using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTaxSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _mContext;

        public CountriesController(AppDbContext aContext)
        {
            _mContext = aContext;
        }

        // GET api/countries
        [HttpGet]
        public ActionResult<List<Country>> Get()
        {
            var list = _mContext.mCountries.Where(c => c.IsActive).Select(c => new {
                Country = c,
                Regions = c.Regions.Where(r => r.IsActive)
            }).ToList();

            if (list.Count < 1) return NotFound();

            return Ok(list);
        }

        // GET api/countries/5
        [HttpGet("{aId}")]
        public ActionResult<Country> Get(int aId)
        {
            var country = _mContext.mCountries.Where(c => c.Id == aId && c.IsActive).Select(Country => new {
                Country,
                Regions = Country.Regions.Where(r => r.IsActive)
            }).First();
            if (country == null) return NotFound();

            return Ok(country);
        }

        // POST api/countries
        [HttpPost]
        public ActionResult<Country> Post(Country aCountry)
        {
            _mContext.mCountries.Add(aCountry);
            _mContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new {aCountry.Id}, aCountry);
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public ActionResult<Country> Put(int aId, Country aCountry)
        {
            if (aId != aCountry.Id) return BadRequest();

            _mContext.Entry(aCountry).State = EntityState.Modified;
            _mContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/countries/5
        [HttpDelete("{aId}")]
        public ActionResult<Country> Delete(int aId)
        {
            var country = _mContext.mCountries.Find(aId);

            if (country == null) return NotFound();

            _mContext.mCountries.Remove(country);
            _mContext.SaveChanges();

            return NoContent();
        }
    }
}