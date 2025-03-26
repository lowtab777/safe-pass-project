using Microsoft.EntityFrameworkCore;
using SafePassAppBackend.Models;

namespace SafePassAppBackend.SPDbContext
{
    public class SafePassDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        // DbSet<AuditLog> AuditLog { get; set; }
        // DbSet<BlockedAccount> BlockedAccounts { get; set; }

        public SafePassDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users table setup
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Login)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();

            // Role table setup


            modelBuilder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(r => r.Id);

            modelBuilder.Entity<Role>()
                .Property(r => r.RoleName)
                .IsRequired();

            // UserRole table setup
            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles")
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(r => r.UserId);

        }
    }
}
