namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cafeAlbum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CafeAlbumLanguages",
                c => new
                    {
                        CafeAlbumId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.CafeAlbumId, t.LanguageId })
                .ForeignKey("dbo.CafeAlbums", t => t.CafeAlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.CafeAlbumId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.CafeAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(),
                        ParentId = c.Int(),
                        PhotoName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CafeAlbums", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CafeAlbumLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.CafeAlbumLanguages", "CafeAlbumId", "dbo.CafeAlbums");
            DropForeignKey("dbo.CafeAlbums", "ParentId", "dbo.CafeAlbums");
            DropIndex("dbo.CafeAlbums", new[] { "ParentId" });
            DropIndex("dbo.CafeAlbumLanguages", new[] { "LanguageId" });
            DropIndex("dbo.CafeAlbumLanguages", new[] { "CafeAlbumId" });
            DropTable("dbo.CafeAlbums");
            DropTable("dbo.CafeAlbumLanguages");
        }
    }
}
