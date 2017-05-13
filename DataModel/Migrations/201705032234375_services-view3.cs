namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicesview3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "CreateDate");
        }
    }
}
