namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingDecimalBack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "PriceNumber", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "PFee", c => c.Decimal(nullable: false, storeType: "money"));
            //AlterColumn("dbo.Shipments", "PCharges", c => c.Decimal(nullable: false, storeType: "money"));
            //AlterColumn("dbo.Shipments", "ShipCharge", c => c.Decimal(nullable: false, storeType: "money"));
            //AlterColumn("dbo.Shipments", "Total", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Shipments", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "ShipCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "PCharges", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "PFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Prices", "PriceNumber", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
