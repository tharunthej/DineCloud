using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineCloud.Infrastructure.Configurations
{
    public class MealBookingConfiguration : IEntityTypeConfiguration<MealBooking>
    {
        public void Configure(EntityTypeBuilder<MealBooking> builder) 
        {
            // Table
            builder.ToTable("MealBooking");

            // Primary Key
            builder.HasKey(m => m.Id);

            // Properties
            builder.Property(m => m.BookingDate)
                   .IsRequired();

            builder.Property(m => m.MealPrice)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(m => m.CreatedAt)
                   .IsRequired();

            builder.Property(m => m.UpdatedAt)
                   .IsRequired(false);

            // Indexes / Constraints

            // CRITICAL: One booking per employee per day
            builder.HasIndex(m => new { m.EmployeeId, m.BookingDate })
                   .IsUnique();

            // Relationships

            // MealBooking -> Employee (Many-to-One)
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.MealBookings)
                   .HasForeignKey(m => m.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // MealBooking -> Week (Many-to-One)
            builder.HasOne(m => m.Week)
                   .WithMany(w => w.MealBookings)
                   .HasForeignKey(m => m.WeekId)
                   .OnDelete(DeleteBehavior.Restrict);

            // MealBooking -> MealType (Many-to-One)
            builder.HasOne(m => m.MealType)
                   .WithMany(mt => mt.MealBookings)
                   .HasForeignKey(m => m.MealTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
