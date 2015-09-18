namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredMan2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Raws", "Manufacturer", c => c.String(nullable: false));
            AlterColumn("dbo.Raws", "ManPartNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raws", "ManPartNumber", c => c.String());
            AlterColumn("dbo.Raws", "Manufacturer", c => c.String());
        }
    }
}
