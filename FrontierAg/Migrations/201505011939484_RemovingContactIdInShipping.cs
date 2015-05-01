namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingContactIdInShipping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shippings", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Shippings", new[] { "ContactId" });
            RenameColumn(table: "dbo.Shippings", name: "ContactId", newName: "Contact_ContactId");
            AlterColumn("dbo.Shippings", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Shippings", "Contact_ContactId");
            AddForeignKey("dbo.Shippings", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shippings", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Shippings", new[] { "Contact_ContactId" });
            AlterColumn("dbo.Shippings", "Contact_ContactId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Shippings", name: "Contact_ContactId", newName: "ContactId");
            CreateIndex("dbo.Shippings", "ContactId");
            AddForeignKey("dbo.Shippings", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
