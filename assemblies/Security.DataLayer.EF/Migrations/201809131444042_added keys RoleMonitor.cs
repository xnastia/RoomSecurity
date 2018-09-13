namespace Security.DataLayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedkeysRoleMonitor : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RoleMonitors", "RoleId");
            CreateIndex("dbo.RoleMonitors", "MonitorId");
            AddForeignKey("dbo.RoleMonitors", "MonitorId", "dbo.Monitors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleMonitors", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMonitors", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleMonitors", "MonitorId", "dbo.Monitors");
            DropIndex("dbo.RoleMonitors", new[] { "MonitorId" });
            DropIndex("dbo.RoleMonitors", new[] { "RoleId" });
        }
    }
}
