namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterEntering1stCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "PPhone", c => c.String());
            AlterColumn("dbo.Contacts", "PPType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PPType", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "PPhone", c => c.String(nullable: false));
        }
    }
}
