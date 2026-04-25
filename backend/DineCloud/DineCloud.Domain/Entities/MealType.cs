
namespace DineCloud.Domain.Entities
{
    public class MealType
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public decimal CurrentPrice { get; set; }

        public bool IsActive { get; set; }

        // Navigation
        public ICollection<MealBooking> MealBookings { get; set; } = new List<MealBooking>();
    }
}
