using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolicyManagement.Controllers;
using PolicyManagement.Tests.Fakes;

namespace PolicyManagement.Tests
{
    [TestClass]
    public class PoliciesControllerTests
    {
        [TestMethod]
        public void Create_AddingPolicyWithNoErrors_PolicyIsSaved()
        {
            var db = new FakePolicyManagementDb();
            db.AddSet(TestData.Policies);
            var controller = new PoliciesController(db);

            controller.Create(new Models.Policy { Id = 1, PolicyNumber = "testing" });

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [TestMethod]
        public void Create_AddingPolicyWithModelStateErrors_PolicyIsNotSaved()
        {
            var db = new FakePolicyManagementDb();
            db.AddSet(TestData.Policies);

            Assert.AreEqual(0, db.Added.Count);

            var controller = new PoliciesController(db);

            controller.ModelState.AddModelError("test", "test");

            controller.Create(policy: new Models.Policy { Id=1, PolicyNumber = "testing" });

            Assert.AreEqual(0, db.Added.Count);
            Assert.AreEqual(false, db.Saved);
        }

        [TestMethod]
        public void Index_RequestData_ViewResultIsReturned()
        {
            var db = new FakePolicyManagementDb();
            db.AddSet(TestData.Policies);

            var controller = new PoliciesController(db);

            ViewResult result = controller.Index() as ViewResult;
            
            Assert.IsNotNull(result);
        }
    }
}
