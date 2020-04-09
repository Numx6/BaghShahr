namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgName = c.String(maxLength: 100),
                        ImgAlt = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 100),
                        SubTitle = c.String(nullable: false, maxLength: 100),
                        CreatDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HomeSliders");
        }
    }
}
