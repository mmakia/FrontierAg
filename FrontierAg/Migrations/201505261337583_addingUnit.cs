namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "Unit", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Unit");
            DropColumn("dbo.CartItems", "Unit");
        }
    }
}
