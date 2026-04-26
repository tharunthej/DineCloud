using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DineCloud.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<MealBooking> MealBookings { get; set; }
        public DbSet<MonthlyDeduction> MonthlyDeductions { get; set; }

        // Fluent API Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Automatically applies all IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        // Audit Handling (CreatedAt / UpdatedAt)
        public override int SaveChanges()
        {
            SetAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditFields()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is Employee ||
                    entry.Entity is MealBooking ||
                    entry.Entity is MonthlyDeduction ||
                    entry.Entity is Week)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                    }
                }
            }
        }
    }
}
