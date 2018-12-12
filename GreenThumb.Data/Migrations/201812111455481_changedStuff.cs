namespace GreenThumb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Material", "TypeOfMaterial", c => c.Int(nullable: false));
            DropColumn("dbo.Material", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Material", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Material", "TypeOfMaterial");
        }
    }
}
