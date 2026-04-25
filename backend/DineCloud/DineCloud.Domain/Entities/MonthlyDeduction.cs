
namespace DineCloud.Domain.Entities
{
    public class MonthlyDeduction
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime GeneratedAt { get; set; }
        public bool IsLocked { get; set; }

        public int GeneratedBy { get; set; }

        // Navigation
        public Employee Employee { get; set; } = null!;
        public Employee GeneratedByEmployee { get; set; } = null!;
    }
}
