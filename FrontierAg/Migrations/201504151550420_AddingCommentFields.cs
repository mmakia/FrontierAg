namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCommentFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Comment", c => c.String());
            AddColumn("dbo.Orders", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Comment");
            DropColumn("dbo.OrderDetails", "Comment");
        }
    }
}
