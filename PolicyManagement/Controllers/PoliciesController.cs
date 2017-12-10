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
        IPolicyManagementDb db;

        public PoliciesController()
        {
            db = new PolicyManagementDb();
        }

        public PoliciesController(IPolicyManagementDb _db)
        {
            db = _db;
        }

        // GET: Policies
        public ActionResult Index()
        {
            List<Policy> results = db.Query<Policy>()
                                    .Include(x => x.InsuredCustomer)
                                    .Include(x => x.InsuredCustomer.CustomerAddress)
                                    .Include(x => x.InsuredRiskEntity)
                                    .Include(x => x.InsuredRiskEntity.RiskAddress).ToList();

            return View(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Policy policy)
        {
            Policy p = db.Query<Policy>().ToList()
                .Where(x => x.PolicyNumber.Trim().ToLower() == policy.PolicyNumber.Trim().ToLower())
                .FirstOrDefault();

            if(p!=null)
            {
                ModelState.AddModelError("PolicyNumber", "There is already a policy with such identifier.");
            }

            if (ModelState.IsValid)
            {
                db.Add(policy);
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
    }
}
