namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalProductIdInPrices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prices", "ProductId", "dbo.Products");
            DropIndex("dbo.Prices", new[] { "ProductId" });
            AlterColumn("dbo.Prices", "ProductId", c => c.Int());
            CreateIndex("dbo.Prices", "ProductId");
            AddForeignKey("dbo.Prices", "ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ProductId", "dbo.Products");
            DropIndex("dbo.Prices", new[] { "ProductId" });
            AlterColumn("dbo.Prices", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prices", "ProductId");
            AddForeignKey("dbo.Prices", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
