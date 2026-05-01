
using System.ComponentModel.DataAnnotations;

namespace DineCloud.Application.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public required string EmployeeCode { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
