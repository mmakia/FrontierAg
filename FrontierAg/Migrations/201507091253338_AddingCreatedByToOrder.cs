namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCreatedByToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreatedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "CreatedBy_Id");
            AddForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "CreatedBy_Id" });
            DropColumn("dbo.Orders", "CreatedBy_Id");
        }
    }
}
