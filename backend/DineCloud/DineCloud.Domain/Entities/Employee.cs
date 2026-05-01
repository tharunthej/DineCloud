
namespace DineCloud.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public required string EmployeeCode { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Role Role { get; set; } = null!;

        public ICollection<MealBooking> MealBookings { get; set; } = new List<MealBooking>();
        public ICollection<MonthlyDeduction> MonthlyDeductions { get; set; } = new List<MonthlyDeduction>();
        public ICollection<MonthlyDeduction> GeneratedDeductions { get; set; } = new List<MonthlyDeduction>();
    }
}
