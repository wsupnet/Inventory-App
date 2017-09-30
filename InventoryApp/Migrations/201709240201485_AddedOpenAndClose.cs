namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOpenAndClose : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Open", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Stores", "Close", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Close");
            DropColumn("dbo.Stores", "Open");
        }
    }
}
