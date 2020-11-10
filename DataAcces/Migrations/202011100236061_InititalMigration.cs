namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipality",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Region");
            DropTable("dbo.Municipality");
        }
    }
}
