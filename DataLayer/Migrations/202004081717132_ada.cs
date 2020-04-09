namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EquipmentProducts", "EquipmentTitle", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EquipmentProducts", "EquipmentTitle", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
