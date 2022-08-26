using C_mart_APIs.Model;
using Microsoft.EntityFrameworkCore;

namespace C_mart_APIs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.User_Roles)
                .HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<User_Role>()
               .HasOne(x => x.User)
               .WithMany(y => y.User_Roles)
               .HasForeignKey(x => x.UserId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
    }
}
