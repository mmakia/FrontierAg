namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingisShipping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "isShipping", c => c.Boolean(nullable: false));
            DropColumn("dbo.Shippings", "SType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shippings", "SType", c => c.Int());
            DropColumn("dbo.Shippings", "isShipping");
        }
    }
}
