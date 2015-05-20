namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSTypeToShipping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "SType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippings", "SType");
        }
    }
}
