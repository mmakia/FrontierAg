namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturningContactIdInShipping : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Shippings", name: "Contact_ContactId", newName: "ContactId");
            RenameIndex(table: "dbo.Shippings", name: "IX_Contact_ContactId", newName: "IX_ContactId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Shippings", name: "IX_ContactId", newName: "IX_Contact_ContactId");
            RenameColumn(table: "dbo.Shippings", name: "ContactId", newName: "Contact_ContactId");
        }
    }
}
