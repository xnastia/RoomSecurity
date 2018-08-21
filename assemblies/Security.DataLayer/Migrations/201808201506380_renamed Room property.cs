namespace Security.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedRoomproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "UiId", c => c.Guid(nullable: false));
            DropColumn("dbo.Rooms", "GuidId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "GuidId", c => c.Guid(nullable: false));
            DropColumn("dbo.Rooms", "UiId");
        }
    }
}
