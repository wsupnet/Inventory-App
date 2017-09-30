namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryPendingChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Price", c => c.Single(nullable: false));
        }
    }
}
