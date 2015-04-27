namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingOrderandOrderDetail2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "QtyShipped", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "QtyCancelled", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Payment", c => c.String());
            AddColumn("dbo.Orders", "PaymentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Closed", c => c.Boolean(nullable: false));
            DropColumn("dbo.OrderDetails", "ContactId");
            DropColumn("dbo.Orders", "TransactionId");
            DropColumn("dbo.Orders", "TransactionDate");
            DropColumn("dbo.Orders", "HasBeenShipped");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "HasBeenShipped", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "TransactionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "TransactionId", c => c.String());
            AddColumn("dbo.OrderDetails", "ContactId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Closed");
            DropColumn("dbo.Orders", "PaymentDate");
            DropColumn("dbo.Orders", "Payment");
            DropColumn("dbo.OrderDetails", "QtyCancelled");
            DropColumn("dbo.OrderDetails", "QtyShipped");
        }
    }
}
