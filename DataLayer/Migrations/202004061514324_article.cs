namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class article : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "ShortDiscript", c => c.String(nullable: false, maxLength: 450));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "ShortDiscript", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
