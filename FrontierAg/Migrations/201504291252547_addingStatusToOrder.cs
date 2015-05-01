namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingStatusToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.Int());
            DropColumn("dbo.Orders", "Closed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Closed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Status");
        }
    }
}
