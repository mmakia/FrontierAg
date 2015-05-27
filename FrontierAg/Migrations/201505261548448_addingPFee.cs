namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPFee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PFee");
        }
    }
}
