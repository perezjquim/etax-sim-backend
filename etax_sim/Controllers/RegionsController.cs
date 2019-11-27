using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using etax_sim.Models;

namespace etax_sim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AppDbContext _mContext;

        public RegionsController(AppDbContext aContext)
        {
            _mContext = aContext;
        }

        [HttpGet]
        public ActionResult<List<Region>> Get()
        {
            var regions = _mContext.mRegions.Include("Companies").ToList();
            if (regions.Count < 1) return NotFound();

            return Ok(regions);
        }

        // GET api/countries/5
        [HttpGet("{aIdid}")]
        public ActionResult<Region> Get(int aId)
        {
            var region = _mContext.mRegions.Find(aId);
            if (region == null) return NotFound();

            _mContext.Entry(region).Collection("Companies").Load();
            return Ok(region);
        }

        // POST api/countries
        [HttpPost]
        public ActionResult<Region> Post(Region aRegion)
        {
            _mContext.mRegions.Add(aRegion);
            _mContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { aRegion.Id }, aRegion);
        }

        // PUT api/countries/5
        [HttpPut("{aId}")]
        public ActionResult<Region> Put(int aId, Region aRegion)
        {
            if (aId != aRegion.Id) return BadRequest();

            _mContext.Entry(aRegion).State = EntityState.Modified;
            _mContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/countries/5
        [HttpDelete("{aId}")]
        public ActionResult<Region> Delete(int aId)
        {
            var region = _mContext.mCountries.Find(aId);

            if (region == null) return NotFound();

            _mContext.mCountries.Remove(region);
            _mContext.SaveChanges();

            return Ok(region);
        }
    }
}