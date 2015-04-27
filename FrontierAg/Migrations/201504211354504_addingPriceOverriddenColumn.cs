namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPriceOverriddenColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "PriceOverridden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "PriceOverridden");
        }
    }
}
