using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineCloud.Infrastructure.Configurations
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            // Table
            builder.ToTable("Holiday");

            // Key
            builder.HasKey(h => h.Id);

            // Properties
            builder.Property(h => h.HolidayDate)
                   .IsRequired();

            builder.Property(h => h.Reason)
                   .IsRequired()
                   .HasMaxLength(150);

            // Unique constraint (one holiday per date)
            builder.HasIndex(h => h.HolidayDate)
                   .IsUnique();
        }
    }
}
