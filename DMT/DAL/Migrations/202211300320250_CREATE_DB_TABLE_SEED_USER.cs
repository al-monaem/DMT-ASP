namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CREATE_DB_TABLE_SEED_USER : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Refunds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ticket_id = c.Int(nullable: false),
                        transaction_id = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        user_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tickets", t => t.ticket_id, cascadeDelete: false)
                .ForeignKey("dbo.Transactions", t => t.transaction_id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.ticket_id)
                .Index(t => t.transaction_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        route_id = c.Int(nullable: false),
                        status = c.String(defaultValue: "active"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Routes", t => t.route_id, cascadeDelete: false)
                .Index(t => t.route_id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        station_1 = c.String(nullable: false, maxLength: 128),
                        station_2 = c.String(nullable: false, maxLength: 128),
                        price = c.Int(nullable: false),
                        Station_id = c.String(maxLength: 128),
                        Station_id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Stations", t => t.Station_id)
                .ForeignKey("dbo.Stations", t => t.Station_id1)
                .ForeignKey("dbo.Stations", t => t.station_1, cascadeDelete: false)
                .ForeignKey("dbo.Stations", t => t.station_2, cascadeDelete: false)
                .Index(t => t.station_1)
                .Index(t => t.station_2)
                .Index(t => t.Station_id)
                .Index(t => t.Station_id1);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        latitude = c.String(nullable: false),
                        longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(defaultValue: "paid"),
                        date = c.DateTime(nullable: false),
                        method = c.String(nullable: false, maxLength: 20),
                        user_id = c.String(nullable: false, maxLength: 128),
                        ticket_id = c.Int(nullable: false),
                        transaction_id = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tickets", t => t.ticket_id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.user_id)
                .Index(t => t.ticket_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 70),
                        email = c.String(nullable: false, maxLength: 30),
                        phone = c.String(nullable: false, maxLength: 30),
                        nid = c.String(),
                        dob = c.DateTime(),
                        wallet = c.Int(nullable: false),
                        profilePic = c.String(),
                        role = c.Int(nullable: false, defaultValue:0),
                        resettoken = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        accessToken = c.String(nullable: false, maxLength: 50),
                        userId = c.String(nullable: false, maxLength: 128),
                        created_at = c.DateTime(nullable: false),
                        expired_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tickets_sold_app = c.Int(nullable: false),
                        tickets_sold_manual = c.Int(nullable: false),
                        revenue_app = c.Int(nullable: false),
                        revenue_manual = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Refunds", "user_id", "dbo.Users");
            DropForeignKey("dbo.Refunds", "transaction_id", "dbo.Transactions");
            DropForeignKey("dbo.Refunds", "ticket_id", "dbo.Tickets");
            DropForeignKey("dbo.Transactions", "user_id", "dbo.Users");
            DropForeignKey("dbo.Tokens", "userId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "ticket_id", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "route_id", "dbo.Routes");
            DropForeignKey("dbo.Routes", "station_2", "dbo.Stations");
            DropForeignKey("dbo.Routes", "station_1", "dbo.Stations");
            DropForeignKey("dbo.Routes", "Station_id1", "dbo.Stations");
            DropForeignKey("dbo.Routes", "Station_id", "dbo.Stations");
            DropIndex("dbo.Tokens", new[] { "userId" });
            DropIndex("dbo.Transactions", new[] { "ticket_id" });
            DropIndex("dbo.Transactions", new[] { "user_id" });
            DropIndex("dbo.Routes", new[] { "Station_id1" });
            DropIndex("dbo.Routes", new[] { "Station_id" });
            DropIndex("dbo.Routes", new[] { "station_2" });
            DropIndex("dbo.Routes", new[] { "station_1" });
            DropIndex("dbo.Tickets", new[] { "route_id" });
            DropIndex("dbo.Refunds", new[] { "user_id" });
            DropIndex("dbo.Refunds", new[] { "transaction_id" });
            DropIndex("dbo.Refunds", new[] { "ticket_id" });
            DropTable("dbo.Revenues");
            DropTable("dbo.Tokens");
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Stations");
            DropTable("dbo.Routes");
            DropTable("dbo.Tickets");
            DropTable("dbo.Refunds");
        }
    }
}
