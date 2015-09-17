namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpdateOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Raws", "ExpDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raws", "ExpDate", c => c.DateTime(nullable: false));
        }
    }
}
