using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DineCloud.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table
            builder.ToTable("Employee");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.EmployeeCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(e => e.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                   .IsRequired();

            builder.Property(e => e.UpdatedAt)
                   .IsRequired(false);

            // Indexes / Constraints
            builder.HasIndex(e => e.Email)
                   .IsUnique();

            builder.HasIndex(e => e.EmployeeCode)
                   .IsUnique();

            // Relationships

            // Employee -> Role (Many-to-One)
            builder.HasOne(e => e.Role)
                   .WithMany(r => r.Employees)
                   .HasForeignKey(e => e.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Employee -> MealBookings (One-to-Many)
            builder.HasMany(e => e.MealBookings)
                   .WithOne(m => m.Employee)
                   .HasForeignKey(m => m.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Employee -> MonthlyDeductions (One-to-Many)
            builder.HasMany(e => e.MonthlyDeductions)
                   .WithOne(md => md.Employee)
                   .HasForeignKey(md => md.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Employee -> GeneratedDeductions (One-to-Many, second FK)
            builder.HasMany(e => e.GeneratedDeductions)
                   .WithOne(md => md.GeneratedByEmployee)
                   .HasForeignKey(md => md.GeneratedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
