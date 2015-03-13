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
using S00127670_CA1.Models;

namespace S00127670_CA1.Controllers
{
    [RoutePrefix("api/col")]
    public class CollegesController : ApiController
    {
        private CollegeDb db = new CollegeDb();

        // GET: api/Colleges
        [Route("api/getall")]
        public IQueryable<College> Getcollege()
        {
            return db.college;
        }

        // GET: api/Colleges/5
        [ResponseType(typeof(College))]
        [Route("api/getcol/{id:int}")]
        public IHttpActionResult GetCollege(int id)
        {
            College college = db.college.Find(id);
            if (college == null)
            {
                return NotFound();
            }

            return Ok(college);
        }

        [Route("getcolinfo/{id:int}")]
        public dynamic GetColInfo(int id)
        {
            College col = db.college.Find(id);
            if (col == null)
                return NotFound();
            return Ok(new {name=col.name, addOne=col.addressOne, addTwo=col.addressTwo, found=col.founded, roll=col.enrollment});
        }

        // PUT: api/Colleges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollege(int id, College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != college.id)
            {
                return BadRequest();
            }

            db.Entry(college).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
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

        // POST: api/Colleges
        [ResponseType(typeof(College))]
        public IHttpActionResult PostCollege(College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.college.Add(college);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = college.id }, college);
        }

        // DELETE: api/Colleges/5
        [ResponseType(typeof(College))]
        public IHttpActionResult DeleteCollege(int id)
        {
            College college = db.college.Find(id);
            if (college == null)
            {
                return NotFound();
            }

            db.college.Remove(college);
            db.SaveChanges();

            return Ok(college);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollegeExists(int id)
        {
            return db.college.Count(e => e.id == id) > 0;
        }
    }
}