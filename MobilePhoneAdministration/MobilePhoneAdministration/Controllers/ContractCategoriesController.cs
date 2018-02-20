using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobilePhoneAdministration.Models;

namespace MobilePhoneAdministration.Controllers
{
    public class ContractCategoriesController : Controller
    {
        private MobilePhoneAdministrationContext db = new MobilePhoneAdministrationContext();

        // GET: ContractCategories
        public ActionResult Index()
        {
            return View(db.ContractCategories.ToList());
        }

        // GET: ContractCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            if (contractCategory == null)
            {
                return HttpNotFound();
            }
            return View(contractCategory);
        }

        // GET: ContractCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ContractCategory contractCategory)
        {
            if (ModelState.IsValid)
            {
                db.ContractCategories.Add(contractCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contractCategory);
        }

        // GET: ContractCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            if (contractCategory == null)
            {
                return HttpNotFound();
            }
            return View(contractCategory);
        }

        // POST: ContractCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ContractCategory contractCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contractCategory);
        }

        // GET: ContractCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            if (contractCategory == null)
            {
                return HttpNotFound();
            }
            return View(contractCategory);
        }

        // POST: ContractCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            db.ContractCategories.Remove(contractCategory);
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
