namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        isForOrder = c.Boolean(nullable: false),
                        isForShipment = c.Boolean(nullable: false),
                        EmailDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emails");
        }
    }
}
