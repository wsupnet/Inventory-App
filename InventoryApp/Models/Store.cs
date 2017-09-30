using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        public TimeSpan Open { get; set; }
        public TimeSpan Close { get; set; }

        public int EmployeeID { get; set; } 

        [ForeignKey("EmployeeID")]
        public virtual Employee employee { get; set; }
    }
}