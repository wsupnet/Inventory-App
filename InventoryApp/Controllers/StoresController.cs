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
using InventoryApp.ViewModel;
using System.Threading.Tasks;

namespace InventoryApp.Controllers
{
    public class StoresController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Stores
        public ActionResult Index()
        {
            return View(db.Stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            EmployeesDetailsViewModel model = new EmployeesDetailsViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Store store = db.Stores.Find(id);
            model.Store = db.Stores.Find(id);//Find Stores
            model.Inventories = db.Inventories.Where(x => x.Stores.ID == id).ToList(); //Find all inventories for a store

            if (model.Store == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetPartialView(int Id)
        {
            var model = db.Inventories.Where(x => x.Stores.ID == Id).ToList(); //Find all inventories for a store

            if (model.Count() > 0)
            {
                return PartialView("_InventoryList", model);
            }

            return PartialView("_NoResultsFound");
        }


        [HttpGet]
        public async Task<ActionResult> GetPartialStoresView(int Id)
        {
            var model = db.Stores.Where(x => x.employee.ID == Id).ToList(); //Find all inventories for a store

            if (model.Count() > 0)
            {
                return PartialView("_StoresList", model);
            }

            return PartialView("_NoResultsFound");
        }


        // GET: Stores/Create
        public ActionResult Create()
        {
            //Create DropdownList
            ViewBag.EmployeeID = db.Employees.Where(x => x.IsActive == true).ToList();

            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Address,IsActive,OpenDate,Open,Close,EmployeeID,Rating")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax([Bind(Include = "ID,Name,Description,Address,IsActive,OpenDate,Open,Close,EmployeeID,Rating")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();

                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    SuccessMsg = "Success"
                });
            }
            else
            {
                return this.Json(new
                {
                    EnableError = true,
                    ErrorTitle = "Error",
                    ErrorMsg = "Something goes wrong, please try again later"
                });
            }

        }


        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            //Create DropdownList. Make sure the viewbagname does not match any property names in the Model
            ViewBag.EmployeeDropDownList = db.Employees.Where(x => x.IsActive == true).ToList();
            
            //IEnumerable<SelectListItem> EmployeeDropDownList = db.Employees.Select(x => new SelectListItem
            //{
            //    Value = x.ID.ToString(),
            //    Text = (x.FirstName + " " + x.LastName)
            //});
            //ViewBag.EmployeeID = EmployeeDropDownList;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Address,IsActive,OpenDate,Open,Close,EmployeeID,Rating")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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

        public ActionResult AddInventory(int id)
        {
            return RedirectToAction("Index", "Inventories", new { storeId = id });
        }

    }
}
