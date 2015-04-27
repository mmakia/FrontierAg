namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddingContactInOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Orders", new[] { "Contact_ContactId" });
            RenameColumn(table: "dbo.Orders", name: "Contact_ContactId", newName: "ContactId");
            AlterColumn("dbo.Orders", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ContactId");
            AddForeignKey("dbo.Orders", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Orders", new[] { "ContactId" });
            AlterColumn("dbo.Orders", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "ContactId", newName: "Contact_ContactId");
            CreateIndex("dbo.Orders", "Contact_ContactId");
            AddForeignKey("dbo.Orders", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
