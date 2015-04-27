namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingShippingIdtoOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShippingId");
        }
    }
}
