namespace Lodi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegionUserRelationShip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Region_Id", newName: "RegionId");
            DropPrimaryKey("dbo.Idols");
            DropPrimaryKey("dbo.Regions");
            CreateTable(
                "dbo.ApplicationUserIdols",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Idol_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Idol_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Idols", t => t.Idol_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Idol_Id);
            
            AlterColumn("dbo.Idols", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Regions", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "RegionId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Idols", "Id");
            AddPrimaryKey("dbo.Regions", "Id");
            CreateIndex("dbo.AspNetUsers", "RegionId");
            AddForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.ApplicationUserIdols", "Idol_Id", "dbo.Idols");
            DropForeignKey("dbo.ApplicationUserIdols", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserIdols", new[] { "Idol_Id" });
            DropIndex("dbo.ApplicationUserIdols", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "RegionId" });
            DropPrimaryKey("dbo.Regions");
            DropPrimaryKey("dbo.Idols");
            AlterColumn("dbo.AspNetUsers", "RegionId", c => c.Guid());
            AlterColumn("dbo.Regions", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Idols", "Id", c => c.Guid(nullable: false, identity: true));
            DropTable("dbo.ApplicationUserIdols");
            AddPrimaryKey("dbo.Regions", "Id");
            AddPrimaryKey("dbo.Idols", "Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "RegionId", newName: "Region_Id");
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
        }
    }
}
