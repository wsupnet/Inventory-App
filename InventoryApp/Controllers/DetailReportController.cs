using InventoryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class DetailReportController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: DetailReport
        public ActionResult Index()
        {
            //Get a list of stores
            ViewBag.Stores = db.Stores.ToList();

            return View();
        }

        public ActionResult Employees()
        {
            ViewBag.Employees = db.Employees.ToList();

            return View();
        }

        public ActionResult Stores()
        {
            ViewBag.Employees = db.Employees.ToList();

            return View();
        }

        public ActionResult EmployeeReport()
        {
            var DataSource = db.Employees.ToList();
            ViewBag.datasource = DataSource;
            return View();
        }

        public ActionResult InventoryPerStore()
        {
            var DataSourceStores = db.Stores.ToList();

            var DataSourceInventory = from Inventory in db.Inventories
                                      select new
                                      {
                                          StoreID = Inventory.Stores.ID,
                                          Name = Inventory.Name
                                      };

            ViewBag.datasourceStores = DataSourceStores;
            ViewBag.datasourceInventory = DataSourceInventory.ToList();

            return View();

        }

    }
}