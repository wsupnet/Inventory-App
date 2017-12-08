using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? EmployeeId { get; set; }

        public int? StoreId { get; set; }

        public bool? IsActive { get; set; }

        public string Description { get; set; }

        public bool IsAllDay { get; set; }

        public string IsRecurrence { get; set; }

        public string RecurrenceRule { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        //[ForeignKey("EmployeeId")]
        //public virtual Employee Employees { get; set; }

        //[ForeignKey("StoreId")]
        //public virtual Store Stores { get; set; }
    }
}