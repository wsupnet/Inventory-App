namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRatingFromIntToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Rating", c => c.Int(nullable: false));
        }
    }
}
