namespace TaskMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackSizeName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        PackSizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PackSizes", t => t.PackSizeId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PackSizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PackSizeId", "dbo.PackSizes");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "PackSizeId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.PackSizes");
            DropTable("dbo.Categories");
        }
    }
}
