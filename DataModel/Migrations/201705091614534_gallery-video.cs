namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galleryvideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GalleryVideoLanguages",
                c => new
                    {
                        GalleryVideoId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(),
                        Video = c.String(),
                    })
                .PrimaryKey(t => new { t.GalleryVideoId, t.LanguageId })
                .ForeignKey("dbo.GalleryVideos", t => t.GalleryVideoId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.GalleryVideoId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.GalleryVideos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SliderLanguages", "GalleryVideo_Id", c => c.Int());
            CreateIndex("dbo.SliderLanguages", "GalleryVideo_Id");
            AddForeignKey("dbo.SliderLanguages", "GalleryVideo_Id", "dbo.GalleryVideos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GalleryVideoLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.GalleryVideoLanguages", "GalleryVideoId", "dbo.GalleryVideos");
            DropForeignKey("dbo.SliderLanguages", "GalleryVideo_Id", "dbo.GalleryVideos");
            DropIndex("dbo.SliderLanguages", new[] { "GalleryVideo_Id" });
            DropIndex("dbo.GalleryVideoLanguages", new[] { "LanguageId" });
            DropIndex("dbo.GalleryVideoLanguages", new[] { "GalleryVideoId" });
            DropColumn("dbo.SliderLanguages", "GalleryVideo_Id");
            DropTable("dbo.GalleryVideos");
            DropTable("dbo.GalleryVideoLanguages");
        }
    }
}
