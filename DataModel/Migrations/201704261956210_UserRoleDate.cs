namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "RegistrationDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Users", "LastLoginDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastLoginDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "RegistrationDate", c => c.DateTime(nullable: false));
        }
    }
}
