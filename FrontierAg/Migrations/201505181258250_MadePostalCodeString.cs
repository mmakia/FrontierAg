namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadePostalCodeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PostalCode", c => c.Int());
        }
    }
}
