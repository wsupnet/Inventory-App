using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryApp.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base("DefaultConnection")
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LK_EmployeeTypes> LK_EmployeeTypes { get; set; }

        //Inventory Table to assign to each store individually
        
        public DbSet<StoreCategory> Categories { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
    }
}