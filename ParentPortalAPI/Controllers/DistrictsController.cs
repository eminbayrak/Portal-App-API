using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ParentPortalAPI.Models;

namespace ParentPortalAPI.Controllers
{
    public class DistrictsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Districts
        public IQueryable<District> GetDistricts()
        {
            return db.Districts;
        }

        // GET: api/Districts/5
        [ResponseType(typeof(District))]
        public IHttpActionResult GetDistrict(int id)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        // PUT: api/Districts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistrict(int id, District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != district.Id)
            {
                return BadRequest();
            }

            db.Entry(district).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Districts
        [ResponseType(typeof(District))]
        public IHttpActionResult PostDistrict(District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Districts.Add(district);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = district.Id }, district);
        }

        // DELETE: api/Districts/5
        [ResponseType(typeof(District))]
        public IHttpActionResult DeleteDistrict(int id)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return NotFound();
            }

            db.Districts.Remove(district);
            db.SaveChanges();

            return Ok(district);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistrictExists(int id)
        {
            return db.Districts.Count(e => e.Id == id) > 0;
        }
    }
}