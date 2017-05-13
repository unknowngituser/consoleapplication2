namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Albums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumLanguages",
                c => new
                    {
                        AlbumId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(),
                        Descrition = c.String(),
                    })
                .PrimaryKey(t => new { t.AlbumId, t.LanguageId })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(),
                        ParentId = c.Int(),
                        PhotoName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.ParentId)
                .Index(t => t.ParentId);
            
            AlterColumn("dbo.News", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.AlbumLanguages", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ParentId", "dbo.Albums");
            DropIndex("dbo.Albums", new[] { "ParentId" });
            DropIndex("dbo.AlbumLanguages", new[] { "LanguageId" });
            DropIndex("dbo.AlbumLanguages", new[] { "AlbumId" });
            AlterColumn("dbo.News", "CreateDate", c => c.DateTime(nullable: false));
            DropTable("dbo.Albums");
            DropTable("dbo.AlbumLanguages");
        }
    }
}
