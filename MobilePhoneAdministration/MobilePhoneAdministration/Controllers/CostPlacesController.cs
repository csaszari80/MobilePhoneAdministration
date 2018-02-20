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
    public class CostPlacesController : Controller
    {
        private MobilePhoneAdministrationContext db = new MobilePhoneAdministrationContext();

        // GET: CostPlaces
        public ActionResult Index()
        {
            return View(db.CostPlaces.ToList());
        }

        // GET: CostPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostPlace costPlace = db.CostPlaces.Find(id);
            if (costPlace == null)
            {
                return HttpNotFound();
            }
            return View(costPlace);
        }

        // GET: CostPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CostCode,CostName,OrganizationCode,OrganizationName,ForwardedBill")] CostPlace costPlace)
        {
            if (ModelState.IsValid)
            {
                db.CostPlaces.Add(costPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costPlace);
        }

        // GET: CostPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostPlace costPlace = db.CostPlaces.Find(id);
            if (costPlace == null)
            {
                return HttpNotFound();
            }
            return View(costPlace);
        }

        // POST: CostPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CostCode,CostName,OrganizationCode,OrganizationName,ForwardedBill")] CostPlace costPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costPlace);
        }

        // GET: CostPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostPlace costPlace = db.CostPlaces.Find(id);
            if (costPlace == null)
            {
                return HttpNotFound();
            }
            return View(costPlace);
        }

        // POST: CostPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CostPlace costPlace = db.CostPlaces.Find(id);
            db.CostPlaces.Remove(costPlace);
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
