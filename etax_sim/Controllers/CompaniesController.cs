using System.Collections.Generic;
using System.Linq;
using eTaxSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTaxSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext mContext;

        public CompaniesController(AppDbContext aContext)
        {
            mContext = aContext;
        }

        // GET api/companies
        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            var list = mContext.mCompanies.Include("Roles").Include("Region").Include("Region.Country").Include("Sector").ToList();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // GET api/companies/5
        [HttpGet("{aId}")]
        public ActionResult<Country> Get(int aId)
        {
            var company = mContext.mCompanies.Find(aId);
            if (company == null)
            {
                return NotFound();
            }
            mContext.Entry(company).Collection("Roles").Load();
            mContext.Entry(company).Reference("Region").Load();
            //falta adicionar aqui o Region.Country
            mContext.Entry(company).Reference("Sector").Load();
            return Ok(company);
        }

        // POST api/companies
        [HttpPost]
        public ActionResult<Company> Post(Company aCompany)
        {
            mContext.mCompanies.Add(aCompany);
            mContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { Id = aCompany.Id }, aCompany);
        }

        // PUT api/companies/5
        [HttpPut("{aId}")]
        public ActionResult<Company> Put(int aId, Company aCompany)
        {
            if (aId != aCompany.Id)
            {
                return BadRequest();
            }

            mContext.Entry(aCompany).State = EntityState.Modified;
            mContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/companies/5
        [HttpDelete("{aId}")]
        public ActionResult<Country> Delete(int aId)
        {
            var company = mContext.mCompanies.Find(aId);

            if (company == null)
            {
                return NotFound();
            }

            mContext.mCompanies.Remove(company);
            mContext.SaveChanges();

            return Ok(company);
        }
    }
}
