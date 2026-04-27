
namespace DineCloud.Domain.Entities
{
    public class Holiday
    {
        public int Id { get; set; }

        public DateOnly HolidayDate { get; set; }

        public required string Reason { get; set; }
    }
}
