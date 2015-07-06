namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingActionToShipment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "Action", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shipments", "Action");
        }
    }
}
