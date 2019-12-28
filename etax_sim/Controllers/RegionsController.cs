using System.Collections.Generic;
using System.Linq;
using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTaxSim.Controllers
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

        [HttpGet("{aId}")]
        public ActionResult<Region> Get(int aId)
        {
            var region = _mContext.mRegions.Find(aId);
            if (region == null) return NotFound();

            _mContext.Entry(region).Collection("Companies").Load();
            return Ok(region);
        }

        [HttpPost]
        public ActionResult<Region> Post(Region aRegion)
        {
            _mContext.mRegions.Add(aRegion);
            _mContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { aRegion.Id }, aRegion);
        }

        [HttpPut("{aId}")]
        public ActionResult<Region> Put(int aId, Region aRegion)
        {
            if (aId != aRegion.Id) return BadRequest();

            _mContext.Entry(aRegion).State = EntityState.Modified;
            _mContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{aId}")]
        public ActionResult<Region> Delete(int aId)
        {
            var region = _mContext.mCountries.Find(aId);

            if (region == null) return NotFound();

            _mContext.mCountries.Remove(region);
            _mContext.SaveChanges();

            return NoContent();
        }
    }
}