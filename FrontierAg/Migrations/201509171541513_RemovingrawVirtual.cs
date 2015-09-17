namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingrawVirtual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RawProducts", "Raw_RawId", "dbo.Raws");
            DropForeignKey("dbo.RawProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.RawProducts", new[] { "Raw_RawId" });
            DropIndex("dbo.RawProducts", new[] { "Product_ProductId" });
            AddColumn("dbo.Products", "Raw_RawId", c => c.Int());
            CreateIndex("dbo.Products", "Raw_RawId");
            AddForeignKey("dbo.Products", "Raw_RawId", "dbo.Raws", "RawId");
            DropTable("dbo.RawProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RawProducts",
                c => new
                    {
                        Raw_RawId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Raw_RawId, t.Product_ProductId });
            
            DropForeignKey("dbo.Products", "Raw_RawId", "dbo.Raws");
            DropIndex("dbo.Products", new[] { "Raw_RawId" });
            DropColumn("dbo.Products", "Raw_RawId");
            CreateIndex("dbo.RawProducts", "Product_ProductId");
            CreateIndex("dbo.RawProducts", "Raw_RawId");
            AddForeignKey("dbo.RawProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.RawProducts", "Raw_RawId", "dbo.Raws", "RawId", cascadeDelete: true);
        }
    }
}
