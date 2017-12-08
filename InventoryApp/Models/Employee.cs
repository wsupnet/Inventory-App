using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Employee
    {
       public int ID { get; set; }

       public string FirstName { get; set; }

       public string LastName { get; set; }

       public int EmployeeID { get; set; }

       public bool IsActive { get; set; }
       
       public int LK_EmployeeTypesID { get; set; }

        public int StoreID { get; set; }

        //[ForeignKey("LK_EmployeeTypesID")]
        //public virtual LK_EmployeeTypes lk_EmployeeTypes { get; set; }

       public int Position { get; set; }

        [ForeignKey("Position")]
        public virtual Position Positions { get; set; }
    }
}