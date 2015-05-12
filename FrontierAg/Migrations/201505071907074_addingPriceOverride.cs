namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPriceOverride : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "PriceOverride", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "PriceOverride", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "PriceOverride");
            DropColumn("dbo.CartItems", "PriceOverride");
        }
    }
}
