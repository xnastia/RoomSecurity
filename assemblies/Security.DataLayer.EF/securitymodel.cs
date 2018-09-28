namespace Security.DataLayer.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class securitymodel : DbContext
    {
        public securitymodel()
            : base("name=securitymodel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AlarmStatu> AlarmStatus { get; set; }
        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<PresenceRule> PresenceRules { get; set; }
        public virtual DbSet<RoleMonitor> RoleMonitors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
