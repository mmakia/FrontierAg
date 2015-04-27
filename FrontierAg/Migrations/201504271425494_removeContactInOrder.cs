namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeContactInOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Orders", new[] { "ContactId" });
            RenameColumn(table: "dbo.Orders", name: "ContactId", newName: "Contact_ContactId");
            AlterColumn("dbo.Orders", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Orders", "Contact_ContactId");
            AddForeignKey("dbo.Orders", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Orders", new[] { "Contact_ContactId" });
            AlterColumn("dbo.Orders", "Contact_ContactId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "Contact_ContactId", newName: "ContactId");
            CreateIndex("dbo.Orders", "ContactId");
            AddForeignKey("dbo.Orders", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
