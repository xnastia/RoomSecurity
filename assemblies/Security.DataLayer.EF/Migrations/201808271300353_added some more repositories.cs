namespace Security.DataLayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomemorerepositories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlarmStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        BadgeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Badges", t => t.BadgeId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.BadgeId);
            
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UiId = c.Guid(nullable: false),
                        Name = c.String(),
                        MonitorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monitors", t => t.MonitorId, cascadeDelete: true)
                .Index(t => t.MonitorId);
            
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UiId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.PresenceRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        BadgeId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Badges", t => t.BadgeId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.BadgeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresenceRules", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.PresenceRules", "BadgeId", "dbo.Badges");
            DropForeignKey("dbo.Cameras", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AlarmStatus", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "MonitorId", "dbo.Monitors");
            DropForeignKey("dbo.AlarmStatus", "BadgeId", "dbo.Badges");
            DropIndex("dbo.PresenceRules", new[] { "BadgeId" });
            DropIndex("dbo.PresenceRules", new[] { "RoomId" });
            DropIndex("dbo.Cameras", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "MonitorId" });
            DropIndex("dbo.AlarmStatus", new[] { "BadgeId" });
            DropIndex("dbo.AlarmStatus", new[] { "RoomId" });
            DropTable("dbo.Users");
            DropTable("dbo.PresenceRules");
            DropTable("dbo.Cameras");
            DropTable("dbo.Monitors");
            DropTable("dbo.Rooms");
            DropTable("dbo.Badges");
            DropTable("dbo.AlarmStatus");
        }
    }
}
