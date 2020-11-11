namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingRegionAndMinicipalitiesColums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Municipality", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Municipality", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Municipality", "Status", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Region", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Region", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "Name");
            DropColumn("dbo.Region", "Code");
            DropColumn("dbo.Municipality", "Status");
            DropColumn("dbo.Municipality", "Name");
            DropColumn("dbo.Municipality", "Code");
        }
    }
}
