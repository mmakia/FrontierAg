namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingShippingToShipments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "ShippingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shipments", "ShippingId");
            AddForeignKey("dbo.Shipments", "ShippingId", "dbo.Shippings", "ShippingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "ShippingId", "dbo.Shippings");
            DropIndex("dbo.Shipments", new[] { "ShippingId" });
            DropColumn("dbo.Shipments", "ShippingId");
        }
    }
}
