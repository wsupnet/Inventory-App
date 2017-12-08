namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedLKTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "LK_EmployeeTypesID", "dbo.LK_EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "LK_EmployeeTypesID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Employees", "LK_EmployeeTypesID");
            AddForeignKey("dbo.Employees", "LK_EmployeeTypesID", "dbo.LK_EmployeeTypes", "ID", cascadeDelete: true);
        }
    }
}
