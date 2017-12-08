using InventoryApp.Data;
using InventoryApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class SchedulesController : Controller
    {

        InventoryContext db = new InventoryContext();

        // GET: Schedules
        public ActionResult Index()
        {
            //Schedule schedules = new Schedule();
            //var model = db.Schedules.ToList();
            //return View(model);

            return View();
        }

        public JsonResult SchedulerDataSource()
        {
            IEnumerable data = db.Schedules.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SchedulerAdd(Schedule value)
        {
            db.Entry(value).State = EntityState.Added;
            db.SaveChanges();

            IEnumerable data = db.Schedules.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Crud(EditParams param)
        {
            var value = param.value;
            if (param.action == "batch")
            {
                value = param.added[0];
                db.Entry(value).State = EntityState.Added;
                db.SaveChanges();
            }

            IEnumerable data = db.Schedules.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public class EditParams
        {
            public string key { get; set; }
            public string action { get; set; }
            public List<Schedule> added { get; set; }
            public List<Schedule> changed { get; set; }
            public Schedule value { get; set; }

        }
    }
}