namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seoextracontent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeoDescriptionLanguages", "ExtraContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SeoDescriptionLanguages", "ExtraContent");
        }
    }
}
