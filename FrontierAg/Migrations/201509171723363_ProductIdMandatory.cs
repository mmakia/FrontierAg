namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductIdMandatory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Raws", "ProductId", "dbo.Products");
            DropIndex("dbo.Raws", new[] { "ProductId" });
            AlterColumn("dbo.Raws", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Raws", "ProductId");
            AddForeignKey("dbo.Raws", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Raws", "ProductId", "dbo.Products");
            DropIndex("dbo.Raws", new[] { "ProductId" });
            AlterColumn("dbo.Raws", "ProductId", c => c.Int());
            CreateIndex("dbo.Raws", "ProductId");
            AddForeignKey("dbo.Raws", "ProductId", "dbo.Products", "ProductId");
        }
    }
}
