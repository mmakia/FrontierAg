namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVendorFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Raws", "Vendor", c => c.String(nullable: false));
            AddColumn("dbo.Raws", "VendorPartNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Raws", "VendorPartNumber");
            DropColumn("dbo.Raws", "Vendor");
        }
    }
}
