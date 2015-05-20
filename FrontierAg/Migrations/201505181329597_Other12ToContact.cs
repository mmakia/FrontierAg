namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Other12ToContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Other1", c => c.String());
            AddColumn("dbo.Contacts", "Other2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Other2");
            DropColumn("dbo.Contacts", "Other1");
        }
    }
}
