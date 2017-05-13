namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeoLang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeoDescriptionLanguages",
                c => new
                    {
                        SeoDescriptionId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.SeoDescriptionId, t.LanguageId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.SeoDescriptions", t => t.SeoDescriptionId, cascadeDelete: true)
                .Index(t => t.SeoDescriptionId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeoDescriptionLanguages", "SeoDescriptionId", "dbo.SeoDescriptions");
            DropForeignKey("dbo.SeoDescriptionLanguages", "LanguageId", "dbo.Languages");
            DropIndex("dbo.SeoDescriptionLanguages", new[] { "LanguageId" });
            DropIndex("dbo.SeoDescriptionLanguages", new[] { "SeoDescriptionId" });
            DropTable("dbo.SeoDescriptionLanguages");
        }
    }
}
