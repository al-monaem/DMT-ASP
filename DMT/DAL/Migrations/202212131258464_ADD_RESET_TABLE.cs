namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_RESET_TABLE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OTP = c.Int(nullable: false),
                        issuedAt = c.DateTime(nullable: false, defaultValue:DateTime.Now),
                        expiresAt = c.DateTime(nullable: false, defaultValue: DateTime.Now.AddMinutes(5)),
                        user_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resets", "user_id", "dbo.Users");
            DropIndex("dbo.Resets", new[] { "user_id" });
            DropTable("dbo.Resets");
        }
    }
}
