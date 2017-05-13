namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeoDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.News", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Photo");
            DropTable("dbo.SeoDescriptions");
        }
    }
}
