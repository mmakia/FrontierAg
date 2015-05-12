namespace FrontierAg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adingPackCharge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackCharges",
                c => new
                    {
                        PackChargeId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        PackChargeAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PackChargeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackCharges", "ProductId", "dbo.Products");
            DropIndex("dbo.PackCharges", new[] { "ProductId" });
            DropTable("dbo.PackCharges");
        }
    }
}
