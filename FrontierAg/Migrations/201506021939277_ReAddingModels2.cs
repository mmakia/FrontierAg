namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddingModels2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ShipmentDetailId)
                .ForeignKey("dbo.Shipments", t => t.ShipmentId, cascadeDelete: true)
                .Index(t => t.ShipmentId);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        ShipmentId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Tracking = c.String(),
                        ShipCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShipmentId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentDetails", "ShipmentId", "dbo.Shipments");
            DropForeignKey("dbo.Shipments", "OrderId", "dbo.Orders");
            DropIndex("dbo.Shipments", new[] { "OrderId" });
            DropIndex("dbo.ShipmentDetails", new[] { "ShipmentId" });
            DropTable("dbo.Shipments");
            DropTable("dbo.ShipmentDetails");
        }
    }
}
