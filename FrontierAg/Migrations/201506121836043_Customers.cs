namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        LName = c.String(),
                        FName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.Int(),
                        PostalCode = c.String(),
                        Country = c.String(maxLength: 40),
                        PPhone = c.String(),
                        PPType = c.Int(),
                        SPhone = c.String(),
                        SPType = c.Int(),
                        Fax = c.String(),
                        EMail = c.String(),
                        WebSite = c.String(),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.Orders", "CustomerId", c => c.Int());
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "CustomerId");
            DropColumn("dbo.Contacts", "isHistory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "isHistory", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropColumn("dbo.Orders", "CustomerId");
            DropTable("dbo.Customers");
        }
    }
}
