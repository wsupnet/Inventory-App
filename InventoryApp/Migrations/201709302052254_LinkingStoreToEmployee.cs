namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkingStoreToEmployee : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Stores", "EmployeeID");
            AddForeignKey("dbo.Stores", "EmployeeID", "dbo.Employees", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Stores", new[] { "EmployeeID" });
            DropColumn("dbo.Stores", "EmployeeID");
        }
    }
}
