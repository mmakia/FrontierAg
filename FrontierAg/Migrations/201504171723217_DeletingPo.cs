namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingPo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Poes", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Poes", new[] { "ContactId" });
            DropTable("dbo.Poes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Poes",
                c => new
                    {
                        PoId = c.Int(nullable: false, identity: true),
                        PoNumber = c.String(nullable: false),
                        ContactId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PoId);
            
            CreateIndex("dbo.Poes", "ContactId");
            AddForeignKey("dbo.Poes", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
