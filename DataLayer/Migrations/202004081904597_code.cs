namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class code : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Code", c => c.Int(nullable: false));
        }
    }
}
