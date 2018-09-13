namespace Security.DataLayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedroles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleMonitors",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        MonitorId = c.Int(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Monitors", t => t.MonitorId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.MonitorId)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RoleMonitors", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RoleMonitors", "MonitorId", "dbo.Monitors");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.RoleMonitors", new[] { "Role_Id" });
            DropIndex("dbo.RoleMonitors", new[] { "MonitorId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.RoleMonitors");
            DropTable("dbo.Roles");
        }
    }
}
