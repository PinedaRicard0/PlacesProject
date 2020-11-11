namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingRegionMunicipalitiesTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegionMunicipalities",
                c => new
                    {
                        RegionId = c.Guid(nullable: false),
                        MunicipalityId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegionId, t.MunicipalityId })
                .ForeignKey("dbo.Municipality", t => t.MunicipalityId, cascadeDelete: true)
                .ForeignKey("dbo.Region", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId)
                .Index(t => t.MunicipalityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegionMunicipalities", "RegionId", "dbo.Region");
            DropForeignKey("dbo.RegionMunicipalities", "MunicipalityId", "dbo.Municipality");
            DropIndex("dbo.RegionMunicipalities", new[] { "MunicipalityId" });
            DropIndex("dbo.RegionMunicipalities", new[] { "RegionId" });
            DropTable("dbo.RegionMunicipalities");
        }
    }
}
