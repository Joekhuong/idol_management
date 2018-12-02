namespace Lodi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForumForIdol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forum",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Idols", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forum", "Id", "dbo.Idols");
            DropIndex("dbo.Forum", new[] { "Id" });
            DropTable("dbo.Forum");
        }
    }
}
