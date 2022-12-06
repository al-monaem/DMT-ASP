namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAX_LENGTH_USERS : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "email" });
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "nid", c => c.String());
            AlterColumn("dbo.Users", "profilePic", c => c.String());
            AlterColumn("dbo.Users", "resettoken", c => c.String());
            CreateIndex("dbo.Users", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "email" });
            AlterColumn("dbo.Users", "resettoken", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "profilePic", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "nid", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "phone", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false, maxLength: 70));
            CreateIndex("dbo.Users", "email", unique: true);
        }
    }
}
