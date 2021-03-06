namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowedNullsForPasswordInUsersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
