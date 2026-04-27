using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineCloud.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Table
            builder.ToTable("Role");

            // Key
            builder.HasKey(r => r.Id);

            // Properties
            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // Relationships
            builder.HasMany(r => r.Employees)
                   .WithOne(e => e.Role)
                   .HasForeignKey(e => e.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint
            builder.HasIndex(r => r.Name)
                   .IsUnique();
        }
    }
}
