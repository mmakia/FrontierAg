namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhoneType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "EMail", c => c.String());
            DropColumn("dbo.Contacts", "PPType");
            DropColumn("dbo.Contacts", "SPType");
            DropColumn("dbo.Customers", "PPType");
            DropColumn("dbo.Customers", "SPType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SPType", c => c.Int());
            AddColumn("dbo.Customers", "PPType", c => c.Int());
            AddColumn("dbo.Contacts", "SPType", c => c.Int());
            AddColumn("dbo.Contacts", "PPType", c => c.Int());
            DropColumn("dbo.Shippings", "EMail");
        }
    }
}
