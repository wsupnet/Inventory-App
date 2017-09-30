namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQtyColumnToInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Sku", c => c.String());
            AddColumn("dbo.Inventories", "Qty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "Qty");
            DropColumn("dbo.Inventories", "Sku");
        }
    }
}
