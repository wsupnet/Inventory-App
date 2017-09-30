namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPriceProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Price", c => c.Decimal(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "Price");
        }
    }
}
