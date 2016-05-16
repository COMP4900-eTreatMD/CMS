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
    public class HospitalListsController : Controller
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: HospitalLists
        public ActionResult Index()
        {
            return View(db.hospitalList.ToList());
        }

        // GET: HospitalLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalList hospitalList = db.hospitalList.Find(id);
            if (hospitalList == null)
            {
                return HttpNotFound();
            }
            return View(hospitalList);
        }

        // GET: HospitalLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "locationID,rankingOrder,country")] HospitalList hospitalList)
        {
            if (ModelState.IsValid)
            {
                db.hospitalList.Add(hospitalList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospitalList);
        }

        // GET: HospitalLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalList hospitalList = db.hospitalList.Find(id);
            if (hospitalList == null)
            {
                return HttpNotFound();
            }
            return View(hospitalList);
        }

        // POST: HospitalLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "locationID,rankingOrder,country")] HospitalList hospitalList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitalList);
        }

        // GET: HospitalLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalList hospitalList = db.hospitalList.Find(id);
            if (hospitalList == null)
            {
                return HttpNotFound();
            }
            return View(hospitalList);
        }

        // POST: HospitalLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospitalList hospitalList = db.hospitalList.Find(id);
            db.hospitalList.Remove(hospitalList);
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
