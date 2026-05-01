using System.ComponentModel.DataAnnotations;

namespace DineCloud.Application.DTOs.Employee
{
    public class EmployeeUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? EmployeeCode { get; set; }

        public int? RoleId { get; set; }

        public bool? IsActive { get; set; }

    }
}
