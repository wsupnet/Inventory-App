namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKeysToEmployees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "LK_EmployeeTypesID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "LK_EmployeeTypesID");
            AddForeignKey("dbo.Employees", "LK_EmployeeTypesID", "dbo.LK_EmployeeTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "LK_EmployeeTypesID", "dbo.LK_EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "LK_EmployeeTypesID" });
            DropColumn("dbo.Employees", "LK_EmployeeTypesID");
        }
    }
}
