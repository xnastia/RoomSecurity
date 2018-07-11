using System.Data.Entity;

namespace Security.WebSite.Models
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext() : base("DbConnection")
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}