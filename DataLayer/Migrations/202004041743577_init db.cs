namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentProducts",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        EquipmentTitle = c.String(nullable: false, maxLength: 250),
                        CreatDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDiscription = c.String(maxLength: 350),
                        Discription = c.String(),
                        Address = c.String(),
                        Price = c.Long(nullable: false),
                        Slider = c.Boolean(nullable: false),
                        Special = c.Boolean(nullable: false),
                        ImageName = c.String(maxLength: 100),
                        CreatDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductGalleries",
                c => new
                    {
                        GalleryID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 1500),
                        ImageTitle = c.String(nullable: false, maxLength: 350),
                        CreatDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.SpecificationsProducts",
                c => new
                    {
                        SpecificationsID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        Number = c.Int(nullable: false),
                        CreatTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SpecificationsID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationsProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductGalleries", "ProductID", "dbo.Products");
            DropForeignKey("dbo.EquipmentProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.SpecificationsProducts", new[] { "ProductID" });
            DropIndex("dbo.ProductGalleries", new[] { "ProductID" });
            DropIndex("dbo.EquipmentProducts", new[] { "ProductID" });
            DropTable("dbo.SpecificationsProducts");
            DropTable("dbo.ProductGalleries");
            DropTable("dbo.Products");
            DropTable("dbo.EquipmentProducts");
        }
    }
}
