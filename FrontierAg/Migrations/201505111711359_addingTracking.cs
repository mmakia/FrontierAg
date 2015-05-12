namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTracking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Tracking", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Tracking");
        }
    }
}
