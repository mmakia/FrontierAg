namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingOrderPropToShipping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "OrderId", c => c.Int());
            CreateIndex("dbo.Shippings", "OrderId");
            AddForeignKey("dbo.Shippings", "OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shippings", "OrderId", "dbo.Orders");
            DropIndex("dbo.Shippings", new[] { "OrderId" });
            DropColumn("dbo.Shippings", "OrderId");
        }
    }
}
