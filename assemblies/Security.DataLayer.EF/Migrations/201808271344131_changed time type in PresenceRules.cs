namespace Security.DataLayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtimetypeinPresenceRules : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PresenceRules", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.PresenceRules", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PresenceRules", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PresenceRules", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
