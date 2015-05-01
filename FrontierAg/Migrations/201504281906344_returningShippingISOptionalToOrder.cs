namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returningShippingISOptionalToOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Shipping_ShippingId", newName: "ShippingId");
            RenameIndex(table: "dbo.Orders", name: "IX_Shipping_ShippingId", newName: "IX_ShippingId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_ShippingId", newName: "IX_Shipping_ShippingId");
            RenameColumn(table: "dbo.Orders", name: "ShippingId", newName: "Shipping_ShippingId");
        }
    }
}
