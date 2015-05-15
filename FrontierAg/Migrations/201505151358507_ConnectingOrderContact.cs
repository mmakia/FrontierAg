namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectingOrderContact : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Contact_ContactId", newName: "ContactId");
            RenameIndex(table: "dbo.Orders", name: "IX_Contact_ContactId", newName: "IX_ContactId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_ContactId", newName: "IX_Contact_ContactId");
            RenameColumn(table: "dbo.Orders", name: "ContactId", newName: "Contact_ContactId");
        }
    }
}
