
namespace DineCloud.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        // Navigation
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
