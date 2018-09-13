namespace Security.DataLayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Qw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleMonitors", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleMonitors", new[] { "Role_Id" });
            DropColumn("dbo.RoleMonitors", "RoleId");
            RenameColumn(table: "dbo.RoleMonitors", name: "Role_Id", newName: "RoleId");
            DropPrimaryKey("dbo.RoleMonitors");
            AddColumn("dbo.RoleMonitors", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RoleMonitors", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoleMonitors", "RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RoleMonitors", "Id");
            CreateIndex("dbo.RoleMonitors", "RoleId");
            AddForeignKey("dbo.RoleMonitors", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMonitors", "RoleId", "dbo.Roles");
            DropIndex("dbo.RoleMonitors", new[] { "RoleId" });
            DropPrimaryKey("dbo.RoleMonitors");
            AlterColumn("dbo.RoleMonitors", "RoleId", c => c.Int());
            AlterColumn("dbo.RoleMonitors", "RoleId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.RoleMonitors", "Id");
            AddPrimaryKey("dbo.RoleMonitors", "RoleId");
            RenameColumn(table: "dbo.RoleMonitors", name: "RoleId", newName: "Role_Id");
            AddColumn("dbo.RoleMonitors", "RoleId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.RoleMonitors", "Role_Id");
            AddForeignKey("dbo.RoleMonitors", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
