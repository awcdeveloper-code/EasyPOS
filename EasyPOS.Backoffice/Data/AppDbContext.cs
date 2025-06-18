using Microsoft.EntityFrameworkCore;
using EasyPOS.Backoffice.Models;

namespace EasyPOS.Backoffice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActionOfWork> ActionsOfWork { get; set; }
        public DbSet<Log> Logger { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TableOrSeat> TablesOrSeats { get; set; }
        public DbSet<NewFeatureRequest> NewFeatureRequests { get; set; }
        public DbSet<ReportProblem> ReportProblems { get; set; }
        public DbSet<FrecuentCustomer> FrecuentCustomers { get; set; }
        public DbSet<Bucket> Buckets { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Role>().HasKey(u => u.Id);

            modelBuilder.Entity<ActionOfWork>().HasKey(u => u.Id);

            modelBuilder.Entity<Log>().HasKey(u => u.Id);

            modelBuilder.Entity<Category>().HasKey(u => u.Id);

            modelBuilder.Entity<Product>().HasKey(u => u.Id);

            modelBuilder.Entity<TableOrSeat>().HasKey(u => u.Id);

            modelBuilder.Entity<NewFeatureRequest>().HasKey(u => u.Id);

            modelBuilder.Entity<ReportProblem>().HasKey(u => u.Id);

            modelBuilder.Entity<FrecuentCustomer>().HasKey(u => u.Id);

            modelBuilder.Entity<Bucket>().HasKey(u => u.Id);

            // adjust columns type
            modelBuilder.Entity<User>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<User>()
                .Property(e => e.LastLogin)
                .HasColumnType("datetime");

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<Role>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<NewFeatureRequest>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<ReportProblem>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<ActionOfWork>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<FrecuentCustomer>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<FrecuentCustomer>()
                .Property(e => e.LastVisit)
                .HasColumnType("datetime");

            modelBuilder.Entity<Bucket>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<Promotion>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<Ticket>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<Ticket>()
                .Property(e => e.ClosedAt)
                .HasColumnType("datetime");
        }
    }
}
