namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingPriceOverrdie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CartItems", "PriceOverride");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "PriceOverride", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CartItems", "OriginalPrice");
        }
    }
}
