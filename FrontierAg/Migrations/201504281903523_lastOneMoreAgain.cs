namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastOneMoreAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shippings", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Orders", new[] { "ContactId" });
            DropIndex("dbo.Shippings", new[] { "OrderId" });
            RenameColumn(table: "dbo.Orders", name: "ContactId", newName: "Contact_ContactId");
            AddColumn("dbo.Orders", "Shipping_ShippingId", c => c.Int());
            AlterColumn("dbo.Orders", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Orders", "Shipping_ShippingId");
            CreateIndex("dbo.Orders", "Contact_ContactId");
            AddForeignKey("dbo.Orders", "Shipping_ShippingId", "dbo.Shippings", "ShippingId");
            AddForeignKey("dbo.Orders", "Contact_ContactId", "dbo.Contacts", "ContactId");
            DropColumn("dbo.Orders", "ShippingId");
            DropColumn("dbo.Shippings", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shippings", "OrderId", c => c.Int());
            AddColumn("dbo.Orders", "ShippingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Orders", "Shipping_ShippingId", "dbo.Shippings");
            DropIndex("dbo.Orders", new[] { "Contact_ContactId" });
            DropIndex("dbo.Orders", new[] { "Shipping_ShippingId" });
            AlterColumn("dbo.Orders", "Contact_ContactId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Shipping_ShippingId");
            RenameColumn(table: "dbo.Orders", name: "Contact_ContactId", newName: "ContactId");
            CreateIndex("dbo.Shippings", "OrderId");
            CreateIndex("dbo.Orders", "ContactId");
            AddForeignKey("dbo.Orders", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
            AddForeignKey("dbo.Shippings", "OrderId", "dbo.Orders", "OrderId");
        }
    }
}
