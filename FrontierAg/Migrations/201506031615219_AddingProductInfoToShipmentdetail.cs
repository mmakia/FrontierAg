namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProductInfoToShipmentdetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipmentDetails", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.ShipmentDetails", "ProductNo", c => c.String());
            AddColumn("dbo.ShipmentDetails", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipmentDetails", "ProductName");
            DropColumn("dbo.ShipmentDetails", "ProductNo");
            DropColumn("dbo.ShipmentDetails", "ProductId");
        }
    }
}
