namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrderShipping2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ShippingId", "dbo.Shippings");
            DropIndex("dbo.Orders", new[] { "ShippingId" });
            CreateTable(
                "dbo.OrderShippings",
                c => new
                    {
                        OrderShippingId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ShippingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderShippingId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Shippings", t => t.ShippingId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ShippingId);
            
            AddColumn("dbo.Contacts", "isHistory", c => c.Boolean(nullable: false));
            AddColumn("dbo.Shippings", "isHistory", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderShippings", "ShippingId", "dbo.Shippings");
            DropForeignKey("dbo.OrderShippings", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderShippings", new[] { "ShippingId" });
            DropIndex("dbo.OrderShippings", new[] { "OrderId" });
            DropColumn("dbo.Shippings", "isHistory");
            DropColumn("dbo.Contacts", "isHistory");
            DropTable("dbo.OrderShippings");
            CreateIndex("dbo.Orders", "ShippingId");
            AddForeignKey("dbo.Orders", "ShippingId", "dbo.Shippings", "ShippingId");
        }
    }
}
