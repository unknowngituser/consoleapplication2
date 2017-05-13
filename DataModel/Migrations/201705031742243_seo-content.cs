namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seocontent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeoDescriptionLanguages", "PageContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SeoDescriptionLanguages", "PageContent");
        }
    }
}
