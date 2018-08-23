namespace Security.DataLayer.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.Rooms", "MonitorId", "dbo.Monitors");
            DropIndex("dbo.Rooms", new[] { "MonitorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Monitors");
            DropTable("dbo.Rooms");
        }
    }
}
