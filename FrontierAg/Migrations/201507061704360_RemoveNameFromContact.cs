namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameFromContact : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "FName");
            DropColumn("dbo.Contacts", "LName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "LName", c => c.String());
            AddColumn("dbo.Contacts", "FName", c => c.String());
        }
    }
}
