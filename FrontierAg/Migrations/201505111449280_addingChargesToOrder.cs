namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingChargesToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OtherCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Discount");
            DropColumn("dbo.Orders", "OtherCharge");
            DropColumn("dbo.Orders", "ShipCharge");
        }
    }
}
