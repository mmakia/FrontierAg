namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadePostalCodeString2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shippings", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shippings", "PostalCode", c => c.Int());
        }
    }
}
