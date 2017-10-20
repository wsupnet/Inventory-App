using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModel
{
    public class StoreViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
        
        public DateTime OpenDate { get; set; }

        public int EmployeeID { get; set; }

        public string Employee  { get; set; }
    }
}