namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicesview2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ServicesLanguages", name: "AboutId", newName: "ServicesId");
            RenameIndex(table: "dbo.ServicesLanguages", name: "IX_AboutId", newName: "IX_ServicesId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ServicesLanguages", name: "IX_ServicesId", newName: "IX_AboutId");
            RenameColumn(table: "dbo.ServicesLanguages", name: "ServicesId", newName: "AboutId");
        }
    }
}
