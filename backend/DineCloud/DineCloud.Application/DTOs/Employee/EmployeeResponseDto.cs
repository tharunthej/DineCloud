
namespace DineCloud.Application.DTOs.Employee
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? EmployeeCode { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
