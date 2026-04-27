
namespace DineCloud.Domain.Entities
{
    public class Week
    {
        public int Id { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public DateTime FreezeAt { get; set; }
        public DateTime? ReopenStartAt { get; set; }
        public DateTime? ReopenEndAt { get; set; }

        public bool ManuallyFrozen { get; set; }
        public bool PayrollLocked { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<MealBooking> MealBookings { get; set; } = new List<MealBooking>();
    }
}
