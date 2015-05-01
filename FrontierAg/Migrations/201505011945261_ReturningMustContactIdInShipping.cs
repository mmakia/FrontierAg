namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturningMustContactIdInShipping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shippings", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Shippings", new[] { "ContactId" });
            AlterColumn("dbo.Shippings", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shippings", "ContactId");
            AddForeignKey("dbo.Shippings", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shippings", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Shippings", new[] { "ContactId" });
            AlterColumn("dbo.Shippings", "ContactId", c => c.Int());
            CreateIndex("dbo.Shippings", "ContactId");
            AddForeignKey("dbo.Shippings", "ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
