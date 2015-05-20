namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNamesToShipping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "Company", c => c.String());
            AddColumn("dbo.Shippings", "LName", c => c.String());
            AddColumn("dbo.Shippings", "FName", c => c.String());
            AddColumn("dbo.Shippings", "Other1", c => c.String());
            AddColumn("dbo.Shippings", "Other2", c => c.String());
            AddColumn("dbo.Shippings", "PPhone", c => c.String());
            DropColumn("dbo.Contacts", "Other1");
            DropColumn("dbo.Contacts", "Other2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Other2", c => c.String());
            AddColumn("dbo.Contacts", "Other1", c => c.String());
            DropColumn("dbo.Shippings", "PPhone");
            DropColumn("dbo.Shippings", "Other2");
            DropColumn("dbo.Shippings", "Other1");
            DropColumn("dbo.Shippings", "FName");
            DropColumn("dbo.Shippings", "LName");
            DropColumn("dbo.Shippings", "Company");
        }
    }
}
