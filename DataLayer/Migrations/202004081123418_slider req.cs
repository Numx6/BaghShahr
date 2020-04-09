namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sliderreq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HomeSliders", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.HomeSliders", "SubTitle", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HomeSliders", "SubTitle", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.HomeSliders", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
