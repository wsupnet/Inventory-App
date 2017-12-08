namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPositionForeignKeyToEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "Position", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Position");
            AddForeignKey("dbo.Employees", "Position", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Position", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "Position" });
            DropColumn("dbo.Employees", "Position");
            DropTable("dbo.Positions");
        }
    }
}
