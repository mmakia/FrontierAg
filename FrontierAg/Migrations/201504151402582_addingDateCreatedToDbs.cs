namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDateCreatedToDbs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Poes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shippings", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderDetails", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "DateCreated");
            DropColumn("dbo.Shippings", "DateCreated");
            DropColumn("dbo.Poes", "DateCreated");
        }
    }
}
