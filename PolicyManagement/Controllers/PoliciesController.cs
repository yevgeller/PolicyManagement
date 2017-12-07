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
    public class PoliciesController : Controller
    {
        private PolicyManagementDb db = new PolicyManagementDb();

        // GET: Policies
        public ActionResult Index()
        {
            List<Policy> results = db.Policies
                                        .Include(x=>x.InsuredCustomer)
                                        .Include(x=>x.InsuredCustomer.CustomerAddress)
                                        .Include(x=>x.InsuredRiskEntity)
                                        .Include(x=>x.InsuredRiskEntity.RiskAddress).ToList();

            return View(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Policy policy)//([Bind(Include = "Id,PolicyNumber,EffectiveDate,ExpirationDate")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policies.Add(policy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            return View();
        }
        //// GET: Policies/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Policy policy = db.Policies.Find(id);
        //    if (policy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(policy);
        //}


    }
}
