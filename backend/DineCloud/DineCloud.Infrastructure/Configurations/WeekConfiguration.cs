using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineCloud.Infrastructure.Configurations
{
    public class WeekConfiguration : IEntityTypeConfiguration<Week>
    {
        public void Configure(EntityTypeBuilder<Week> builder)
        {
            // Table
            builder.ToTable("Week");

            // Key
            builder.HasKey(w => w.Id);

            // Properties
            builder.Property(w => w.StartDate)
                   .IsRequired();

            builder.Property(w => w.EndDate)
                   .IsRequired();

            builder.Property(w => w.FreezeAt)
                   .IsRequired();

            builder.Property(w => w.CreatedAt)
                   .IsRequired();

            builder.Property(w => w.ManuallyFrozen)
                   .IsRequired();

            builder.Property(w => w.PayrollLocked)
                   .IsRequired();

            // Relationships
            builder.HasMany(w => w.MealBookings)
                   .WithOne(m => m.Week)
                   .HasForeignKey(m => m.WeekId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Table Constraints
            builder.ToTable("Week", table =>
            {
                table.HasCheckConstraint(
                    "CK_Week_DateRange",
                    "[EndDate] >= [StartDate]"
                );
            });
        }
    }
}
