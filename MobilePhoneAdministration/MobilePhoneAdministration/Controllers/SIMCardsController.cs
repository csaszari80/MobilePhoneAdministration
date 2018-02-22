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
    public class SIMCardsController : Controller
    {
        private MobilePhoneAdministrationContext db = new MobilePhoneAdministrationContext();

        // GET: SIMCards
        public ActionResult Index()
        {
            return View(db.SIMCards.Include(x=>x.ContractCategory).OrderBy(x=>x.PhoneNumber).ToList());
        }

        // GET: SIMCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIMCard sIMCard = db.SIMCards.Include(x => x.ContractCategory).Single(x => x.Id == id);
            if (sIMCard == null)
            {
                return HttpNotFound();
            }
            return View(sIMCard);
        }
        /// <summary>
        /// Betölti a választható szerződéskategóriákat paraméterben megadott SIMCard objektum az AssignableContractCategories property-be
        /// </summary>
        /// <param name="user"></param>
        /// <param name="db"></param>
        private static void LoadAssignableContractCategories(SIMCard sIMCard, MobilePhoneAdministrationContext db)
        {
            var contractCategories = new List<ContractCategory>();
            contractCategories = db.ContractCategories.ToList();
            sIMCard.AssignableContractCategories = new SelectList(contractCategories, "Id", "CostCodeAndName");
        }

        // GET: SIMCards/Create
        public ActionResult Create()
        {
            var sIMCard = new SIMCard();
            LoadAssignableContractCategories(sIMCard,db);
            return View();
        }

        // POST: SIMCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContractId,DeviceNumber,ContractDate,PhoneNumber,CardIMEI,PIN1,PIN2,PUK1,PUK2,Comment,ContractCategoryId")] SIMCard sIMCard)
        {

            //A lenyílóról érkező érték alapján kikeressük a szerződéstípust
            var contractCategory = db.ContractCategories.Find(sIMCard.ContractCategoryId);

            //Ha nincs ilyen akkor újra bekérjük
            if (contractCategory == null)
            {
                LoadAssignableContractCategories(sIMCard,db);
                return View(sIMCard);
            }
            db.SIMCards.Attach(sIMCard);

            //Az aktuális SIM kártya ContractCategory propertyjének beállítása
            sIMCard.ContractCategory = contractCategory;
            ModelState.Clear();
            TryValidateModel(sIMCard);

            if (ModelState.IsValid)
            {
                db.SIMCards.Add(sIMCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            LoadAssignableContractCategories(sIMCard, db);
            return View(sIMCard);
        }

        // GET: SIMCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIMCard sIMCard = db.SIMCards.Find(id);
            if (sIMCard == null)
            {
                return HttpNotFound();
            }
            //A kártyához tartozó szerződéskategória betöltése
            db.Entry(sIMCard).Reference(x => x.ContractCategory).Load();

            //Az aktuális ContractCategoryId property beállítása (a lenyíló kezdőpontjához
            sIMCard.ContractCategoryId = sIMCard.ContractCategory.Id;

            //A lenyíló elemei
            LoadAssignableContractCategories(sIMCard, db);
            return View(sIMCard);
        }

        // POST: SIMCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContractId,DeviceNumber,ContractDate,PhoneNumber,CardIMEI,PIN1,PIN2,PUK1,PUK2,Comment,ContractCategoryId")] SIMCard sIMCard)
        {
            //A lenyílóról érkező érték alapján kikeressük a szerződéstípust
            var contractCategory = db.ContractCategories.Find(sIMCard.ContractCategoryId);

            //Ha nincs ilyen akkor újra bekérjük
            if (contractCategory == null)
            {
                LoadAssignableContractCategories(sIMCard, db);
                return View(sIMCard);
            }
            db.SIMCards.Attach(sIMCard);

            //Az aktuális SIM kártya ContractCategory propertyjének beállítása
            sIMCard.ContractCategory = contractCategory;
            ModelState.Clear();
            TryValidateModel(sIMCard);
            
            //Ha érvényes módosítjuk az adatbázist
            if (ModelState.IsValid)
            {
                db.Entry(sIMCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            //Ha nem érvényes betöltjük a lenyíló elemeit és visszaadjuk
            LoadAssignableContractCategories(sIMCard, db);
            return View(sIMCard);
        }

        // GET: SIMCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIMCard sIMCard = db.SIMCards.Include(x => x.ContractCategory).Single(x => x.Id == id);
            if (sIMCard == null)
            {
                return HttpNotFound();
            }
            return View(sIMCard);
        }

        // POST: SIMCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SIMCard sIMCard = db.SIMCards.Find(id);
            db.SIMCards.Remove(sIMCard);
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
