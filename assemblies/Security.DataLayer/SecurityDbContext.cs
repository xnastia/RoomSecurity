using System.Data.Entity;

namespace Security.DataLayer
{
    internal class SecurityDbContext : DbContext
    {
        public SecurityDbContext() : base("DbConnection")
        {
            Database.SetInitializer<SecurityDbContext>(new CreateDatabaseIfNotExists<SecurityDbContext>());
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Monitor> Monitors { get; set; }
    }
}