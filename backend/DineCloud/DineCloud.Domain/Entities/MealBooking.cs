
namespace DineCloud.Domain.Entities
{
    public class MealBooking
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public int WeekId { get; set; }

        public DateOnly BookingDate { get; set; }

        public int MealTypeId { get; set; }
        public decimal MealPrice { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Employee Employee { get; set; } = null!;
        public Week Week { get; set; } = null!;
        public MealType MealType { get; set; } = null!;

    }
}
