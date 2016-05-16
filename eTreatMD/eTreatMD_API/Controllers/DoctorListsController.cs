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
using eTreatMD_Model;

namespace eTreatMD_API.Controllers
{
    public class DoctorListsController : ApiController
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: api/DoctorLists
        public IQueryable<DoctorList> GetdoctorList()
        {
            return db.doctorList;
        }

        // GET: api/DoctorLists/5
        [ResponseType(typeof(DoctorList))]
        public IHttpActionResult GetDoctorList(int id)
        {
            DoctorList doctorList = db.doctorList.Find(id);
            if (doctorList == null)
            {
                return NotFound();
            }

            return Ok(doctorList);
        }

        // PUT: api/DoctorLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctorList(int id, DoctorList doctorList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctorList.locationID)
            {
                return BadRequest();
            }

            db.Entry(doctorList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorListExists(id))
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

        // POST: api/DoctorLists
        [ResponseType(typeof(DoctorList))]
        public IHttpActionResult PostDoctorList(DoctorList doctorList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.doctorList.Add(doctorList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctorList.locationID }, doctorList);
        }

        // DELETE: api/DoctorLists/5
        [ResponseType(typeof(DoctorList))]
        public IHttpActionResult DeleteDoctorList(int id)
        {
            DoctorList doctorList = db.doctorList.Find(id);
            if (doctorList == null)
            {
                return NotFound();
            }

            db.doctorList.Remove(doctorList);
            db.SaveChanges();

            return Ok(doctorList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorListExists(int id)
        {
            return db.doctorList.Count(e => e.locationID == id) > 0;
        }
    }
}