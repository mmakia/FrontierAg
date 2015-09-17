namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRaw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Raws",
                c => new
                    {
                        RawId = c.Int(nullable: false, identity: true),
                        LotNumber = c.String(),
                        Manufacturer = c.String(),
                        ManLotNumber = c.String(),
                        ManPartNumber = c.String(),
                        DateRecived = c.DateTime(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RawId);
            
            CreateTable(
                "dbo.RawProducts",
                c => new
                    {
                        Raw_RawId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Raw_RawId, t.Product_ProductId })
                .ForeignKey("dbo.Raws", t => t.Raw_RawId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Raw_RawId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RawProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.RawProducts", "Raw_RawId", "dbo.Raws");
            DropIndex("dbo.RawProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.RawProducts", new[] { "Raw_RawId" });
            DropTable("dbo.RawProducts");
            DropTable("dbo.Raws");
        }
    }
}
