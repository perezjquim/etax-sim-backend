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
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _mContext;

        public RolesController(AppDbContext aContext)
        {
            _mContext = aContext;
        }

        [HttpGet]
        public ActionResult<List<Role>> Get()
        {
            var roles = _mContext.mCountries.ToList();
            if (roles.Count < 1) return NotFound();

            return Ok(roles);
        }

        [HttpGet("{aId}")]
        public ActionResult<Role> Get(int aId)
        {
            var role = _mContext.mRoles.Find(aId);
            if (role == null) return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public ActionResult<Role> Post(Role aRole)
        {
            _mContext.mRoles.Add(aRole);
            _mContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new {Id = aRole.Id}, aRole);
        }

        [HttpPut("{id}")]
        public ActionResult<Role> Put(int aId, Role aRole)
        {
            if (aId != aRole.Id) return BadRequest();

            _mContext.Entry(aRole).State = EntityState.Modified;
            _mContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{aId}")]
        public ActionResult<Role> Delete(int aId)
        {
            var role = _mContext.mRoles.Find(aId);

            if (role == null) return NotFound();

            _mContext.mRoles.Remove(role);
            _mContext.SaveChanges();

            return NoContent();
        }
    }
}