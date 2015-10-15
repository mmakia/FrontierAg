namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Raws", "Vendor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raws", "Vendor", c => c.String(nullable: false));
        }
    }
}
