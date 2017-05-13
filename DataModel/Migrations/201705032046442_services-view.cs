namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicesview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServicesLanguages",
                c => new
                    {
                        AboutId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.AboutId, t.LanguageId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.AboutId, cascadeDelete: true)
                .Index(t => t.AboutId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicesLanguages", "AboutId", "dbo.Services");
            DropForeignKey("dbo.ServicesLanguages", "LanguageId", "dbo.Languages");
            DropIndex("dbo.ServicesLanguages", new[] { "LanguageId" });
            DropIndex("dbo.ServicesLanguages", new[] { "AboutId" });
            DropTable("dbo.ServicesLanguages");
            DropTable("dbo.Services");
        }
    }
}
