namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingToStore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Rating");
        }
    }
}
