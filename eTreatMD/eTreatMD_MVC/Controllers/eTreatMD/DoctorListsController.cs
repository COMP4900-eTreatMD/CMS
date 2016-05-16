using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eTreatMD_Model;

namespace eTreatMD.Controllers.eTreatMD
{
    public class DoctorListsController : Controller
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: DoctorLists
        public ActionResult Index()
        {
            return View(db.doctorList.ToList());
        }

        // GET: DoctorLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorList doctorList = db.doctorList.Find(id);
            if (doctorList == null)
            {
                return HttpNotFound();
            }
            return View(doctorList);
        }

        // GET: DoctorLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "locationID,rankingOrder,country")] DoctorList doctorList)
        {
            if (ModelState.IsValid)
            {
                db.doctorList.Add(doctorList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorList);
        }

        // GET: DoctorLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorList doctorList = db.doctorList.Find(id);
            if (doctorList == null)
            {
                return HttpNotFound();
            }
            return View(doctorList);
        }

        // POST: DoctorLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "locationID,rankingOrder,country")] DoctorList doctorList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorList);
        }

        // GET: DoctorLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorList doctorList = db.doctorList.Find(id);
            if (doctorList == null)
            {
                return HttpNotFound();
            }
            return View(doctorList);
        }

        // POST: DoctorLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorList doctorList = db.doctorList.Find(id);
            db.doctorList.Remove(doctorList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
