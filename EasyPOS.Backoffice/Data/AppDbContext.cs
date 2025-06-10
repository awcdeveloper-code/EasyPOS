using Microsoft.EntityFrameworkCore;
using EasyPOS.Backoffice.Models;

namespace EasyPOS.Backoffice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Log> Logger { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TablesAndSeats> TablesAndSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Role>().HasKey(u => u.Id);

            modelBuilder.Entity<Models.Action>().HasKey(u => u.Id);

            modelBuilder.Entity<Log>().HasKey(u => u.Id);

            modelBuilder.Entity<Category>().HasKey(u => u.Id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            // Configure the Cost property
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasPrecision(10, 2);

            // Configure the Price property
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TablesAndSeats>().HasKey(u => u.Id);
        }
    }
}
