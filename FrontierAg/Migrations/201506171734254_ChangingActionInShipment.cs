namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingActionInShipment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shipments", "Action", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shipments", "Action", c => c.Int(nullable: false));
        }
    }
}
