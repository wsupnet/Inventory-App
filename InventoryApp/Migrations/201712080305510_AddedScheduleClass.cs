namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScheduleClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        StoreId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.EmployeeId)
                .Index(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Schedules", new[] { "StoreId" });
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropTable("dbo.Schedules");
        }
    }
}
