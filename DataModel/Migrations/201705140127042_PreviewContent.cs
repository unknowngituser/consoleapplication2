namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreviewContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsLanguages", "PreviewContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsLanguages", "PreviewContent");
        }
    }
}
