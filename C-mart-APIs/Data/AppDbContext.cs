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
           // modelBuilder.Entity<CartItem>().HasKey(c => new { c.productId, c.UserId });
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.User_Roles)
                .HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<User_Role>()
               .HasOne(x => x.User)
               .WithMany(y => y.User_Roles)
               .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Product).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            

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
       // public DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
    }
}
