namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReadyDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "ReadyDate", c => c.String(maxLength: 128));
            //AlterColumn("dbo.Shipments", "ReadyDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Shipments", "ReadyDate", c => c.DateTime(nullable: false));
        }
    }
}
