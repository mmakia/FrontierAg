namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovingPFeeRemovingDiscountOtherCharge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "PFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ShipmentDetails", "PCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CartItems", "Charge");
            DropColumn("dbo.Orders", "PFee");
            DropColumn("dbo.Orders", "OtherCharge");
            DropColumn("dbo.Orders", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OtherCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "PFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartItems", "Charge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ShipmentDetails", "PCharge");
            DropColumn("dbo.Shipments", "PFee");
        }
    }
}
