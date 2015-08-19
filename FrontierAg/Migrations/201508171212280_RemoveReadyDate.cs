namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveReadyDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shipments", "ReadyDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shipments", "ReadyDate", c => c.DateTime());
        }
    }
}
