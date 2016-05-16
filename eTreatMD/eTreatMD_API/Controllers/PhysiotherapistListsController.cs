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
    public class PhysiotherapistListsController : ApiController
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: api/PhysiotherapistLists
        public IQueryable<PhysiotherapistList> GetphysiotherapistList()
        {
            return db.physiotherapistList;
        }

        // GET: api/PhysiotherapistLists/5
        [ResponseType(typeof(PhysiotherapistList))]
        public IHttpActionResult GetPhysiotherapistList(int id)
        {
            PhysiotherapistList physiotherapistList = db.physiotherapistList.Find(id);
            if (physiotherapistList == null)
            {
                return NotFound();
            }

            return Ok(physiotherapistList);
        }

        // PUT: api/PhysiotherapistLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhysiotherapistList(int id, PhysiotherapistList physiotherapistList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != physiotherapistList.locationID)
            {
                return BadRequest();
            }

            db.Entry(physiotherapistList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhysiotherapistListExists(id))
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

        // POST: api/PhysiotherapistLists
        [ResponseType(typeof(PhysiotherapistList))]
        public IHttpActionResult PostPhysiotherapistList(PhysiotherapistList physiotherapistList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.physiotherapistList.Add(physiotherapistList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = physiotherapistList.locationID }, physiotherapistList);
        }

        // DELETE: api/PhysiotherapistLists/5
        [ResponseType(typeof(PhysiotherapistList))]
        public IHttpActionResult DeletePhysiotherapistList(int id)
        {
            PhysiotherapistList physiotherapistList = db.physiotherapistList.Find(id);
            if (physiotherapistList == null)
            {
                return NotFound();
            }

            db.physiotherapistList.Remove(physiotherapistList);
            db.SaveChanges();

            return Ok(physiotherapistList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhysiotherapistListExists(int id)
        {
            return db.physiotherapistList.Count(e => e.locationID == id) > 0;
        }
    }
}