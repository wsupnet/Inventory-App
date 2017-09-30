namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "Name", c => c.String(maxLength: 60));
            AlterColumn("dbo.Inventories", "Description", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Description", c => c.String());
            AlterColumn("dbo.Inventories", "Name", c => c.String());
        }
    }
}
