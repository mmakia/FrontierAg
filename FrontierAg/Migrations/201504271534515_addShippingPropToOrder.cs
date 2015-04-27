namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShippingPropToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shippings", "OrderId", "dbo.Orders");
            DropIndex("dbo.Shippings", new[] { "OrderId" });
            AlterColumn("dbo.Orders", "ShippingId", c => c.Int());
            CreateIndex("dbo.Orders", "ShippingId");
            AddForeignKey("dbo.Orders", "ShippingId", "dbo.Shippings", "ShippingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingId", "dbo.Shippings");
            DropIndex("dbo.Orders", new[] { "ShippingId" });
            AlterColumn("dbo.Orders", "ShippingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shippings", "OrderId");
            AddForeignKey("dbo.Shippings", "OrderId", "dbo.Orders", "OrderId");
        }
    }
}
