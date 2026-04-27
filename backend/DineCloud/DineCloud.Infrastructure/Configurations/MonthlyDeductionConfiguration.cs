using DineCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineCloud.Infrastructure.Configurations
{
    public class MonthlyDeductionConfiguration : IEntityTypeConfiguration<MonthlyDeduction>
    {
        public void Configure(EntityTypeBuilder<MonthlyDeduction> builder)
        {
            // Table
            builder.ToTable("MonthlyDeduction"); 

            // Primary Key
            builder.HasKey(md => md.Id);

            // Properties
            builder.Property(md => md.Year)
                   .IsRequired();

            builder.Property(md => md.Month)
                   .IsRequired();

            builder.Property(md => md.TotalAmount)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(md => md.GeneratedAt)
                   .IsRequired();

            builder.Property(md => md.IsLocked)
                   .IsRequired();

            // Indexes / Constraints

            // CRITICAL: One deduction per employee per month
            builder.HasIndex(md => new { md.EmployeeId, md.Year, md.Month })
                   .IsUnique();

            // Relationships

            // MonthlyDeduction -> Employee (whose deduction it is)
            builder.HasOne(md => md.Employee)
                   .WithMany(e => e.MonthlyDeductions)
                   .HasForeignKey(md => md.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // MonthlyDeduction -> Employee (who generated it)
            builder.HasOne(md => md.GeneratedByEmployee)
                   .WithMany(e => e.GeneratedDeductions)
                   .HasForeignKey(md => md.GeneratedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            // Table Constraints
            builder.ToTable("MonthlyDeduction", table =>
            {
                table.HasCheckConstraint(
                    "CK_MonthlyDeduction_Month",
                    "[Month] BETWEEN 1 AND 12"
                );
            });
        }
    }
}
