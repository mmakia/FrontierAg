namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterremovingContactIdent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Contact_Identification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Contact_Identification", c => c.String());
        }
    }
}
