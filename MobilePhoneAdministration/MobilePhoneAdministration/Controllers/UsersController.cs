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
    public class UsersController : Controller
    {
        private MobilePhoneAdministrationContext db = new MobilePhoneAdministrationContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.Include(x => x.CostPlace).Where(x=>x.Editable==true).OrderBy(x => x.Name).ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Include(x=>x.CostPlace).Single(x=>x.Id==id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var user = new User();
            LoadAssignableCostPlaces(user,db);

            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CPID,ADlogin,Active,Editable,Hidden,CostPlaceId")] User user)
        {
            //A lenyílóról érkező érték alapján kikeressük a költséghelyet
            var costPlace = db.CostPlaces.Find(user.CostPlaceId);

            if (costPlace == null)
            {
                LoadAssignableCostPlaces(user, db);
                return View(user);
            }

            db.Users.Attach(user);
                      
            // az aktuális felhasználó Costplace propertyjének beállítása
            user.CostPlace = costPlace;
            ModelState.Clear();
            TryValidateModel(user);

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            LoadAssignableCostPlaces(user, db);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            //A felhasználó költséghelyének betöltése
            db.Entry(user).Reference(x => x.CostPlace).Load();
            //Az aktuális költséghely azonosítójának beállítása
            user.CostPlaceId = user.CostPlace.Id;
            
            //A lenyíló lista elemei
            LoadAssignableCostPlaces(user,db);
            return View(user);
        }

        /// <summary>
        /// Betölti a user objektumba a választható költséghelyek listáját.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="db"></param>
        private static void LoadAssignableCostPlaces(User user, MobilePhoneAdministrationContext db)
        {
            var costPlaces = new List<CostPlace>();
            costPlaces = db.CostPlaces.ToList();
            user.AssignableCostPlaces = new SelectList(costPlaces, "Id", "CostCodeAndName");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CPID,ADlogin,Active,Editable,Hidden,CostPlaceId")] User user)
        {
            //A lenyílóról érkező érték alapján kikeressük a költséghelyet
            var costPlace = db.CostPlaces.Find(user.CostPlaceId);

            if (costPlace == null)
            {
                LoadAssignableCostPlaces(user, db);
                return View(user);
            }
            //Betöltjük a költséghelyet
            db.Users.Attach(user);
            
            db.Entry(user).Reference(x => x.CostPlace).Load();
            // az aktuális felhasználó Costplace propertyjének beállítása
            user.CostPlace = costPlace;
            ModelState.Clear();
            TryValidateModel(user);
            
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            LoadAssignableCostPlaces(user, db);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Include(x => x.CostPlace).Single(x => x.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
