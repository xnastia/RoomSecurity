using System.Data.Entity;
using Security.Entities;

namespace Security.WebSite.Models
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext() : base("DbConnection")
        {
            Database.SetInitializer<SecurityDbContext>(new CreateDatabaseIfNotExists<SecurityDbContext>());
        }
        public DbSet<User> Users { get; set; }
    }
}