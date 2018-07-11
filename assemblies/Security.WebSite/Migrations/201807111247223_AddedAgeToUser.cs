namespace Security.WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAgeToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Age");
        }
    }
}
