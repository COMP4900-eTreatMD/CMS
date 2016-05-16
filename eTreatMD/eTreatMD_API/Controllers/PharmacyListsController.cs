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
    public class PharmacyListsController : ApiController
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: api/PharmacyLists
        public IQueryable<PharmacyList> GetpharmacyList()
        {
            return db.pharmacyList;
        }

        // GET: api/PharmacyLists/5
        [ResponseType(typeof(PharmacyList))]
        public IHttpActionResult GetPharmacyList(int id)
        {
            PharmacyList pharmacyList = db.pharmacyList.Find(id);
            if (pharmacyList == null)
            {
                return NotFound();
            }

            return Ok(pharmacyList);
        }

        // PUT: api/PharmacyLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPharmacyList(int id, PharmacyList pharmacyList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacyList.locationID)
            {
                return BadRequest();
            }

            db.Entry(pharmacyList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyListExists(id))
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

        // POST: api/PharmacyLists
        [ResponseType(typeof(PharmacyList))]
        public IHttpActionResult PostPharmacyList(PharmacyList pharmacyList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pharmacyList.Add(pharmacyList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pharmacyList.locationID }, pharmacyList);
        }

        // DELETE: api/PharmacyLists/5
        [ResponseType(typeof(PharmacyList))]
        public IHttpActionResult DeletePharmacyList(int id)
        {
            PharmacyList pharmacyList = db.pharmacyList.Find(id);
            if (pharmacyList == null)
            {
                return NotFound();
            }

            db.pharmacyList.Remove(pharmacyList);
            db.SaveChanges();

            return Ok(pharmacyList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PharmacyListExists(int id)
        {
            return db.pharmacyList.Count(e => e.locationID == id) > 0;
        }
    }
}