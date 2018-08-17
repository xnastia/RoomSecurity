namespace Security.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedmonitor : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Monitors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
