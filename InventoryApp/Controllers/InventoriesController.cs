using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class InventoriesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Inventories
        public ActionResult Index(int? storeId)
        {
            if (storeId > 0)
            {
                ViewBag.StoreId = storeId;

                return View(db.Inventories.Where(x => x.Stores.ID == storeId).ToList());
            }
            else
            {
                return View(db.Inventories.ToList());
            }
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create(int storeId)
        {
            Inventory model = new Inventory();
            model.Stores = new Store();
            model.Stores.ID = storeId;
            return View(model);
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Sku,Qty,Stores,Price,IsActive")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                inventory.Stores = db.Stores.Where(x => x.ID == inventory.Stores.ID).FirstOrDefault();

                db.Inventories.Add(inventory);
                db.SaveChanges();


                return RedirectToAction("Index", new { storeId = inventory.Stores.ID });
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Sku,Qty,Price,IsActive")] Inventory inventory)
        {
            //Creating a second connection to eliminate any collision with the first database connection
            var store = 0;
            using (InventoryContext context = new InventoryContext()) {
                store = context.Inventories.Where(x => x.ID == inventory.ID).FirstOrDefault().Stores.ID;
                context.Dispose();//forces new connection to close
            }
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return RedirectToAction("Index", new { storeId = store });
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
