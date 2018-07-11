namespace Security.WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeketedAgeFromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
        }
    }
}
