using InventoryApp.Data;
using InventoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class StoreViewModelController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: StoreViewModel
        public ActionResult Index()
        {
            var Results =
                (from Store in db.Stores
                 join Employee in db.Employees
                 on Store.employee.ID equals Employee.ID
                 select new StoreViewModel
                 {
                     Name = Store.Name,
                     Description = Store.Description,
                     Address = Store.Address,
                     IsActive = Store.IsActive,
                     Employee = Store.employee.FirstName + " " + Store.employee.LastName
                 }).ToList();

            return View(Results);
        }
    }
}