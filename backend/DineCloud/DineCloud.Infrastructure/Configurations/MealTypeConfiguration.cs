using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineCloud.Infrastructure.Configurations
{
    public class MealTypeConfiguration : IEntityTypeConfiguration<MealType>
    {
        public void Configure(EntityTypeBuilder<MealType> builder)
        {
            // Table
            builder.ToTable("MealType");

            // Key
            builder.HasKey(mt => mt.Id);

            // Properties
            builder.Property(mt => mt.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(mt => mt.CurrentPrice)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(mt => mt.IsActive)
                   .IsRequired();

            // Relationships
            builder.HasMany(mt => mt.MealBookings)
                   .WithOne(m => m.MealType)
                   .HasForeignKey(m => m.MealTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Prevent duplicate meal names
            builder.HasIndex(mt => mt.Name)
                   .IsUnique();
        }
    }
}
