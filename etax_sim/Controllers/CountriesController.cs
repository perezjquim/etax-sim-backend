using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using etax_sim.Models;

namespace etax_sim.Controllers
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
            var list = _mContext.mCountries.Include("Regions").ToList();

            if (list.Count < 1)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // GET api/countries/5
        [HttpGet("{aId}")]
        public ActionResult<Country> Get(int aId)
        {
            var country = _mContext.mCountries.Find(aId);
            if (country == null) return NotFound();

            _mContext.Entry(country).Collection("Regions").Load();
            return Ok(country);
        }

        // POST api/countries
        [HttpPost]
        public ActionResult<Country> Post(Country aCountry)
        {
            _mContext.mCountries.Add(aCountry);
            _mContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new {Id = aCountry.Id}, aCountry);
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