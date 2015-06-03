namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingShipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        ShippingId = c.Int(nullable: false),
                        OrderDetailsId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        PreviouslyShipped = c.Int(nullable: false),
                        QtyShipping = c.Int(nullable: false),
                        QtyCancelled = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Tracking = c.String(),
                        ShipCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        OrderDetail_OrderDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.ShippingId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_OrderDetailId)
                .ForeignKey("dbo.Shippings", t => t.ShippingId)
                .Index(t => t.ShippingId)
                .Index(t => t.ContactId)
                .Index(t => t.OrderDetail_OrderDetailId);
            
            AddColumn("dbo.Shippings", "ShipmentId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "ShippingId", "dbo.Shippings");
            DropForeignKey("dbo.Shipments", "OrderDetail_OrderDetailId", "dbo.OrderDetails");
            DropForeignKey("dbo.Shipments", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Shipments", new[] { "OrderDetail_OrderDetailId" });
            DropIndex("dbo.Shipments", new[] { "ContactId" });
            DropIndex("dbo.Shipments", new[] { "ShippingId" });
            DropColumn("dbo.Shippings", "ShipmentId");
            DropTable("dbo.Shipments");
        }
    }
}
