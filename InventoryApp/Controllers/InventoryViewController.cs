using InventoryApp.Data;
using InventoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class InventoryViewController : Controller
    {
        private InventoryContext db = new InventoryContext();
        // GET: InventoryView
        public ActionResult Index()
        {
            var Results =
                (from Inventory in db.Inventories
                 join Store in db.Stores
                 on Inventory.Stores.ID equals Store.ID
                 select new InventoryViewModel
                 {
                     Name = Inventory.Name,
                     Description = Inventory.Description,
                     IsActive = Inventory.IsActive,
                     Sku = Inventory.Sku,
                     Qty = Inventory.Qty,
                     Price = Inventory.Price,
                     Store = Inventory.Stores.Name
                 }).ToList();

            return View(Results);
        }
    }
}