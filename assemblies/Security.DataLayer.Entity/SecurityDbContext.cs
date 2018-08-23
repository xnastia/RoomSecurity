using System.Data.Entity;

namespace Security.DataLayer.Entity
{
    internal class SecurityDbContext : DbContext
    {
        public SecurityDbContext() : base("DbConnectionEntity")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SecurityDbContext>());
        }

        public DbSet<AlarmStatus> AlarmStatuses { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<PresenceRules> PresenceRuleses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}