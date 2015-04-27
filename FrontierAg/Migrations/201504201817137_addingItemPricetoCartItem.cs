namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingItemPricetoCartItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "ItemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "ItemPrice");
        }
    }
}
