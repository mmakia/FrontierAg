namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchSTypeToPivot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderShippings", "SType", c => c.Int(nullable: false));
            DropColumn("dbo.Shippings", "SType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shippings", "SType", c => c.Int(nullable: false));
            DropColumn("dbo.OrderShippings", "SType");
        }
    }
}
