namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Stores_ID", c => c.Int());
            CreateIndex("dbo.Inventories", "Stores_ID");
            AddForeignKey("dbo.Inventories", "Stores_ID", "dbo.Stores", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Stores_ID", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "Stores_ID" });
            DropColumn("dbo.Inventories", "Stores_ID");
        }
    }
}
