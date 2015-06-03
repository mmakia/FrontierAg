namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingModels : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ShipmentDetails", "ShipmentId", "dbo.Shipments");
            //DropForeignKey("dbo.Shipments", "OrderDetail_OrderDetailId", "dbo.OrderDetails");
            //DropForeignKey("dbo.Shipments", "Order_OrderId", "dbo.Orders");
            //DropForeignKey("dbo.Shipments", "Contact_ContactId", "dbo.Contacts");
            //DropIndex("dbo.Shipments", new[] { "OrderDetail_OrderDetailId" });
            //DropIndex("dbo.Shipments", new[] { "Order_OrderId" });
            //DropIndex("dbo.Shipments", new[] { "Contact_ContactId" });
            DropIndex("dbo.ShipmentDetails", new[] { "ShipmentId" });
            //DropTable("dbo.Shipments");
            DropTable("dbo.ShipmentDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShipmentDetails",
                c => new
                    {
                        ShipmentDetailId = c.Int(nullable: false, identity: true),
                        ShipmentId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtyShipped = c.Int(nullable: false),
                        QtyShipping = c.Int(nullable: false),
                        QtyCancelled = c.Int(nullable: false),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentDetailId);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        ShipmentId = c.Int(nullable: false, identity: true),
                        Tracking = c.String(),
                        ShipCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDetail_OrderDetailId = c.Int(),
                        Order_OrderId = c.Int(),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.ShipmentId);
            
            CreateIndex("dbo.ShipmentDetails", "ShipmentId");
            CreateIndex("dbo.Shipments", "Contact_ContactId");
            CreateIndex("dbo.Shipments", "Order_OrderId");
            CreateIndex("dbo.Shipments", "OrderDetail_OrderDetailId");
            AddForeignKey("dbo.Shipments", "Contact_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.Shipments", "Order_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Shipments", "OrderDetail_OrderDetailId", "dbo.OrderDetails", "OrderDetailId");
            AddForeignKey("dbo.ShipmentDetails", "ShipmentId", "dbo.Shipments", "ShipmentId", cascadeDelete: true);
        }
    }
}
