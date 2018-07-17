using System.Data.Entity;
using Security.Entities;

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
    }
}