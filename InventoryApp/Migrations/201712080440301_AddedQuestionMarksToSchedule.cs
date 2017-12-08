namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuestionMarksToSchedule : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "StoreId", "dbo.Stores");
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropIndex("dbo.Schedules", new[] { "StoreId" });
            AlterColumn("dbo.Schedules", "EmployeeId", c => c.Int());
            AlterColumn("dbo.Schedules", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Schedules", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "StoreId");
            CreateIndex("dbo.Schedules", "EmployeeId");
            AddForeignKey("dbo.Schedules", "StoreId", "dbo.Stores", "ID");
            AddForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees", "ID", cascadeDelete: true);
        }
    }
}
