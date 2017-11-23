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
using System.Threading.Tasks;
using System.Collections;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.Linq;
using Syncfusion.JavaScript;

namespace InventoryApp.Controllers
{
    public class EmployeesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        public class DataResult
        {
            public IEnumerable result { get; set; }
            public int count { get; set; }
        }

        //Theis method is used to populate the grid
        public ActionResult InlineDataSource(DataManager dataManager)
        {
            //Get the Datasource
            IEnumerable DataSource = db.Employees;

            //Create the object
            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();

            //Populate the objects
            result.result = DataSource;
            result.count = result.result.AsQueryable().Count();

            //Creating conditions to check if we are going to skip any records
            if (dataManager.Skip > 0)
            {
                result.result = operation.PerformSkip(result.result, dataManager.Skip);
            }

            //Check if the user will be taking/removing any objects
            if (dataManager.Take > 0)
            {
                result.result = operation.PerformTake(result.result, dataManager.Take);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InlineEdit(Employee value)
        {
            db.Entry(value).State = EntityState.Modified;
            db.SaveChanges();

            return Json(value, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InlineRemove(int key)
        {
            Employee employee = new Employee();
            employee = db.Employees.Where(x => x.ID == key).FirstOrDefault();

            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(key, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InlineInsert(Employee value)
        {
            db.Entry(value).State = EntityState.Added;
            db.SaveChanges();

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        // GET: Employees
        public ActionResult Index()
        {
            ViewBag.datasource = db.Employees.ToList();

            //Create a dropdown for positions
            ViewBag.DatasourceEmployeeTypes = (from position in db.LK_EmployeeTypes
                                               select new
                                               {
                                                   text = position.Name,
                                                   value = position.ID
                                               }).ToList();

            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            //Create a dropdown list
            ViewBag.LK_EmployeeTypes = db.LK_EmployeeTypes.ToList();

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmployeeID,LK_EmployeeTypesID,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            //Create a dropdown list
            ViewBag.LK_EmployeeTypes = db.LK_EmployeeTypes.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmployeeID,LK_EmployeeTypesID,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> GetPartialView(int Id)
        {
            var model = db.Employees.Where(x => x.StoreID == Id).ToList(); //Find all inventories for a store

            if (model.Count() > 0)
            {
                return PartialView("_EmployeeList", model);
            }

            return PartialView("_NoResultsFound");
        }

        /*
         * We are the creating a Dataresult class that will
         * hold properties. 
         * first, we get the result which populates the grid.
         * second, we get the count of records within the row. Pagination
         */

        


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
