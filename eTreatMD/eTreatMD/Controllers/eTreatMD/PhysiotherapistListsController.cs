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
    public class PhysiotherapistListsController : Controller
    {
        private eTreatMDContext db = new eTreatMDContext();

        // GET: PhysiotherapistLists
        public ActionResult Index()
        {
            return View(db.physiotherapistList.ToList());
        }

        // GET: PhysiotherapistLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysiotherapistList physiotherapistList = db.physiotherapistList.Find(id);
            if (physiotherapistList == null)
            {
                return HttpNotFound();
            }
            return View(physiotherapistList);
        }

        // GET: PhysiotherapistLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhysiotherapistLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "locationID,rankingOrder,country")] PhysiotherapistList physiotherapistList)
        {
            if (ModelState.IsValid)
            {
                db.physiotherapistList.Add(physiotherapistList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(physiotherapistList);
        }

        // GET: PhysiotherapistLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysiotherapistList physiotherapistList = db.physiotherapistList.Find(id);
            if (physiotherapistList == null)
            {
                return HttpNotFound();
            }
            return View(physiotherapistList);
        }

        // POST: PhysiotherapistLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "locationID,rankingOrder,country")] PhysiotherapistList physiotherapistList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physiotherapistList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(physiotherapistList);
        }

        // GET: PhysiotherapistLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysiotherapistList physiotherapistList = db.physiotherapistList.Find(id);
            if (physiotherapistList == null)
            {
                return HttpNotFound();
            }
            return View(physiotherapistList);
        }

        // POST: PhysiotherapistLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhysiotherapistList physiotherapistList = db.physiotherapistList.Find(id);
            db.physiotherapistList.Remove(physiotherapistList);
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
