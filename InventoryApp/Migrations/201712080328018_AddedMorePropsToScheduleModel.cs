namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMorePropsToScheduleModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Title", c => c.String());
            AddColumn("dbo.Schedules", "Description", c => c.String());
            AddColumn("dbo.Schedules", "IsAllDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "IsRecurrence", c => c.String());
            AddColumn("dbo.Schedules", "RecurrenceRule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "RecurrenceRule");
            DropColumn("dbo.Schedules", "IsRecurrence");
            DropColumn("dbo.Schedules", "IsAllDay");
            DropColumn("dbo.Schedules", "Description");
            DropColumn("dbo.Schedules", "Title");
        }
    }
}
