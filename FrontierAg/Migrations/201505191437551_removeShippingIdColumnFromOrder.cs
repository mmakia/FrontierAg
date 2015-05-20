namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeShippingIdColumnFromOrder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "ShippingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ShippingId", c => c.Int());
        }
    }
}
