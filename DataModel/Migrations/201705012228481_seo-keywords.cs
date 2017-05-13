namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seokeywords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsLanguages", "Seo_Keywords", c => c.String());
            AddColumn("dbo.NewsLanguages", "Seo_Description", c => c.String());
            AddColumn("dbo.SeoDescriptionLanguages", "Keywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SeoDescriptionLanguages", "Keywords");
            DropColumn("dbo.NewsLanguages", "Seo_Description");
            DropColumn("dbo.NewsLanguages", "Seo_Keywords");
        }
    }
}
