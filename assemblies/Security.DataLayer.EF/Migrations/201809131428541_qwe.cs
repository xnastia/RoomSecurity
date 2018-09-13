namespace Security.DataLayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwe : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRoles", "Role_Id", c => c.Int());
            AddColumn("dbo.RoleMonitors", "Role_Id", c => c.Int());
            DropPrimaryKey("dbo.UserRoles");
            DropPrimaryKey("dbo.RoleMonitors");
            AlterColumn("dbo.UserRoles", "RoleId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RoleMonitors", "RoleId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.UserRoles", "Id");
            DropColumn("dbo.RoleMonitors", "Id");
            AddPrimaryKey("dbo.UserRoles", "RoleId");
            AddPrimaryKey("dbo.RoleMonitors", "RoleId");
            CreateIndex("dbo.UserRoles", "Role_Id");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.RoleMonitors", "Role_Id");
            CreateIndex("dbo.RoleMonitors", "MonitorId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.RoleMonitors", "Role_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.RoleMonitors", "MonitorId", "dbo.Monitors", "Id", cascadeDelete: true);
        }
    }
}
