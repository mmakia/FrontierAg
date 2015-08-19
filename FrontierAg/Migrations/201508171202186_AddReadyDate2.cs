namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReadyDate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "ReadyDate2", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shipments", "ReadyDate2");
        }
    }
}
