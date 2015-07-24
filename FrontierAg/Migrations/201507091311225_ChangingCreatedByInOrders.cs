namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingCreatedByInOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "CreatedBy_Id" });
            AddColumn("dbo.Orders", "CreatedBy", c => c.String());
            DropColumn("dbo.Orders", "CreatedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CreatedBy_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Orders", "CreatedBy");
            CreateIndex("dbo.Orders", "CreatedBy_Id");
            AddForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
