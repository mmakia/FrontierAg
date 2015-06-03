namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingShipmentDetail3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shipments", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Shipments", new[] { "ContactId" });
            RenameColumn(table: "dbo.Shipments", name: "ContactId", newName: "Contact_ContactId");
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
            
            AddColumn("dbo.Shipments", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Shipments", "Order_OrderId", c => c.Int());
            AlterColumn("dbo.Shipments", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Shipments", "Order_OrderId");
            CreateIndex("dbo.Shipments", "Contact_ContactId");
            AddForeignKey("dbo.Shipments", "Order_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Shipments", "Contact_ContactId", "dbo.Contacts", "ContactId");
            DropColumn("dbo.Shipments", "OrderDetailsId");
            DropColumn("dbo.Shipments", "Qty");
            DropColumn("dbo.Shipments", "Unit");
            DropColumn("dbo.Shipments", "PreviouslyShipped");
            DropColumn("dbo.Shipments", "QtyShipping");
            DropColumn("dbo.Shipments", "QtyCancelled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shipments", "QtyCancelled", c => c.Int(nullable: false));
            AddColumn("dbo.Shipments", "QtyShipping", c => c.Int(nullable: false));
            AddColumn("dbo.Shipments", "PreviouslyShipped", c => c.Int(nullable: false));
            AddColumn("dbo.Shipments", "Unit", c => c.Int(nullable: false));
            AddColumn("dbo.Shipments", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.Shipments", "OrderDetailsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Shipments", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Shipments", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.ShipmentDetails", "ShipmentId", "dbo.Shipments");
            DropIndex("dbo.ShipmentDetails", new[] { "ShipmentId" });
            DropIndex("dbo.Shipments", new[] { "Contact_ContactId" });
            DropIndex("dbo.Shipments", new[] { "Order_OrderId" });
            AlterColumn("dbo.Shipments", "Contact_ContactId", c => c.Int(nullable: false));
            DropColumn("dbo.Shipments", "Order_OrderId");
            DropColumn("dbo.Shipments", "Total");
            DropTable("dbo.ShipmentDetails");
            RenameColumn(table: "dbo.Shipments", name: "Contact_ContactId", newName: "ContactId");
            CreateIndex("dbo.Shipments", "ContactId");
            AddForeignKey("dbo.Shipments", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
