namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_STATIONS : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stations", "latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Stations", "longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stations", "longitude", c => c.String(nullable: false));
            AlterColumn("dbo.Stations", "latitude", c => c.String(nullable: false));
        }
    }
}
