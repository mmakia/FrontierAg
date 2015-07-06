namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotOptionalEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shippings", "SType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shippings", "SType", c => c.Int());
        }
    }
}
