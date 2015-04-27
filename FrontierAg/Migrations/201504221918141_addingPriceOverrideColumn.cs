namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPriceOverrideColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "PriceOverride", c => c.Boolean(nullable: false));
            DropColumn("dbo.CartItems", "PriceOverridden");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "PriceOverridden", c => c.Boolean(nullable: false));
            DropColumn("dbo.CartItems", "PriceOverride");
        }
    }
}
