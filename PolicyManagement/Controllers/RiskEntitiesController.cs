using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PolicyManagement.Models;

namespace PolicyManagement.Controllers
{
    public class RiskEntitiesController : Controller
    {
        private PolicyManagementDb db = new PolicyManagementDb();

        // GET: RiskEntities
        public ActionResult Index()
        {
            return View(db.RiskEntities.ToList());
        }

        // GET: RiskEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskEntity riskEntity = db.RiskEntities.Find(id);
            if (riskEntity == null)
            {
                return HttpNotFound();
            }
            return View(riskEntity);
        }

        // GET: RiskEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RiskConstruction,YearBuilt")] RiskEntity riskEntity)
        {
            if (ModelState.IsValid)
            {
                db.RiskEntities.Add(riskEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskEntity);
        }

        // GET: RiskEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskEntity riskEntity = db.RiskEntities.Find(id);
            if (riskEntity == null)
            {
                return HttpNotFound();
            }
            return View(riskEntity);
        }

        // POST: RiskEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RiskConstruction,YearBuilt")] RiskEntity riskEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskEntity);
        }

        // GET: RiskEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskEntity riskEntity = db.RiskEntities.Find(id);
            if (riskEntity == null)
            {
                return HttpNotFound();
            }
            return View(riskEntity);
        }

        // POST: RiskEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskEntity riskEntity = db.RiskEntities.Find(id);
            db.RiskEntities.Remove(riskEntity);
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
