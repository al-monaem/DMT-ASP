namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_USERS : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "nid", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "profilePic", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "resettoken", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "resettoken", c => c.String());
            AlterColumn("dbo.Users", "profilePic", c => c.String());
            AlterColumn("dbo.Users", "nid", c => c.String());
        }
    }
}
