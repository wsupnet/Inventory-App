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
    public class EmployeeTypeController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: LK_EmployeeType
        public ActionResult Index()
        {
            return View(db.LK_EmployeeTypes.ToList());
        }

        // GET: LK_EmployeeType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LK_EmployeeTypes lK_EmployeeType = db.LK_EmployeeTypes.Find(id);
            if (lK_EmployeeType == null)
            {
                return HttpNotFound();
            }
            return View(lK_EmployeeType);
        }

        // GET: LK_EmployeeType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LK_EmployeeType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] LK_EmployeeTypes lK_EmployeeType)
        {
            if (ModelState.IsValid)
            {
                db.LK_EmployeeTypes.Add(lK_EmployeeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lK_EmployeeType);
        }

        // GET: LK_EmployeeType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LK_EmployeeTypes lK_EmployeeTypes = db.LK_EmployeeTypes.Find(id);
            if (lK_EmployeeTypes == null)
            {
                return HttpNotFound();
            }
            return View(lK_EmployeeTypes);
        }

        // POST: LK_EmployeeType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] LK_EmployeeTypes lK_EmployeeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lK_EmployeeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lK_EmployeeType);
        }

        // GET: LK_EmployeeType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LK_EmployeeTypes lK_EmployeeType = db.LK_EmployeeTypes.Find(id);
            if (lK_EmployeeType == null)
            {
                return HttpNotFound();
            }
            return View(lK_EmployeeType);
        }

        // POST: LK_EmployeeType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LK_EmployeeTypes lK_EmployeeType = db.LK_EmployeeTypes.Find(id);
            db.LK_EmployeeTypes.Remove(lK_EmployeeType);
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
