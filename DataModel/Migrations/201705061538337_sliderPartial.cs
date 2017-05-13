namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sliderPartial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Photo = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SliderLanguages",
                c => new
                    {
                        SliderId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.SliderId, t.LanguageId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Sliders", t => t.SliderId, cascadeDelete: true)
                .Index(t => t.SliderId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderLanguages", "SliderId", "dbo.Sliders");
            DropForeignKey("dbo.SliderLanguages", "LanguageId", "dbo.Languages");
            DropIndex("dbo.SliderLanguages", new[] { "LanguageId" });
            DropIndex("dbo.SliderLanguages", new[] { "SliderId" });
            DropTable("dbo.SliderLanguages");
            DropTable("dbo.Sliders");
        }
    }
}
