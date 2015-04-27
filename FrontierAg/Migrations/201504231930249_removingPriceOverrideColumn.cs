namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingPriceOverrideColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartItems", "PriceOverride");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "PriceOverride", c => c.Boolean(nullable: false));
        }
    }
}
