namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShipmentDetailUnitConvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ProductNo", c => c.String());
            AddColumn("dbo.OrderDetails", "ProductName", c => c.String());
            AddColumn("dbo.ShipmentDetails", "UnitString", c => c.String());
            DropColumn("dbo.ShipmentDetails", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShipmentDetails", "Unit", c => c.Int(nullable: false));
            DropColumn("dbo.ShipmentDetails", "UnitString");
            DropColumn("dbo.OrderDetails", "ProductName");
            DropColumn("dbo.OrderDetails", "ProductNo");
        }
    }
}
