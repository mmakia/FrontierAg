namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueCompany : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contacts", "Company", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "Company" });
        }
    }
}
