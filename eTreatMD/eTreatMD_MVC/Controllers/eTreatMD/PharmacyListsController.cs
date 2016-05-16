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
    public class PharmacyListsController : Controller
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: PharmacyLists
        public ActionResult Index()
        {
            return View(db.pharmacyList.ToList());
        }

        // GET: PharmacyLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyList pharmacyList = db.pharmacyList.Find(id);
            if (pharmacyList == null)
            {
                return HttpNotFound();
            }
            return View(pharmacyList);
        }

        // GET: PharmacyLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PharmacyLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "locationID,rankingOrder,country")] PharmacyList pharmacyList)
        {
            if (ModelState.IsValid)
            {
                db.pharmacyList.Add(pharmacyList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pharmacyList);
        }

        // GET: PharmacyLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyList pharmacyList = db.pharmacyList.Find(id);
            if (pharmacyList == null)
            {
                return HttpNotFound();
            }
            return View(pharmacyList);
        }

        // POST: PharmacyLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "locationID,rankingOrder,country")] PharmacyList pharmacyList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharmacyList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pharmacyList);
        }

        // GET: PharmacyLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyList pharmacyList = db.pharmacyList.Find(id);
            if (pharmacyList == null)
            {
                return HttpNotFound();
            }
            return View(pharmacyList);
        }

        // POST: PharmacyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PharmacyList pharmacyList = db.pharmacyList.Find(id);
            db.pharmacyList.Remove(pharmacyList);
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
