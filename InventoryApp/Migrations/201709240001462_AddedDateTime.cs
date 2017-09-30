namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "OpenDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Inventories", "Description", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Description", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Stores", "OpenDate");
        }
    }
}
