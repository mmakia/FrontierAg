namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOtherChargesToShipment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "OtherCharges", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "PFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "PCharges", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "ShipCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Shipments", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Shipments", "Total", c => c.Decimal(nullable: false, storeType: "money"));
            //AlterColumn("dbo.Shipments", "ShipCharge", c => c.Decimal(nullable: false, storeType: "money"));
            //AlterColumn("dbo.Shipments", "PCharges", c => c.Decimal(nullable: false, storeType: "money"));
            //AlterColumn("dbo.Shipments", "PFee", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.Shipments", "OtherCharges");
        }
    }
}
