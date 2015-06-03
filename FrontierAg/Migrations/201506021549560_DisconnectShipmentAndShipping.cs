namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisconnectShipmentAndShipping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shipments", "ShippingId", "dbo.Shippings");
            DropIndex("dbo.Shipments", new[] { "ShippingId" });
            DropPrimaryKey("dbo.Shipments");
            AddColumn("dbo.Shipments", "ShipmentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Shipments", "ShipmentId");
            DropColumn("dbo.Shipments", "ShippingId");
            DropColumn("dbo.Shippings", "ShipmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shippings", "ShipmentId", c => c.Int());
            AddColumn("dbo.Shipments", "ShippingId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Shipments");
            DropColumn("dbo.Shipments", "ShipmentId");
            AddPrimaryKey("dbo.Shipments", "ShippingId");
            CreateIndex("dbo.Shipments", "ShippingId");
            AddForeignKey("dbo.Shipments", "ShippingId", "dbo.Shippings", "ShippingId");
        }
    }
}
