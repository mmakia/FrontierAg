namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingProductOne2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Raw_RawId", "dbo.Raws");
            DropIndex("dbo.Products", new[] { "Raw_RawId" });
            AddColumn("dbo.Raws", "ProductId", c => c.Int());
            CreateIndex("dbo.Raws", "ProductId");
            AddForeignKey("dbo.Raws", "ProductId", "dbo.Products", "ProductId");
            DropColumn("dbo.Products", "Raw_RawId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Raw_RawId", c => c.Int());
            DropForeignKey("dbo.Raws", "ProductId", "dbo.Products");
            DropIndex("dbo.Raws", new[] { "ProductId" });
            DropColumn("dbo.Raws", "ProductId");
            CreateIndex("dbo.Products", "Raw_RawId");
            AddForeignKey("dbo.Products", "Raw_RawId", "dbo.Raws", "RawId");
        }
    }
}
