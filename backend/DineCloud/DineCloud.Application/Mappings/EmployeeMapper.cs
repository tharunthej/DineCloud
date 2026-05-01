using DineCloud.Application.DTOs.Employee;
using DineCloud.Domain.Entities;

namespace DineCloud.Application.Mappings
{
    public class EmployeeMapper
    {
        public static Employee ToEntity(EmployeeCreateDto dto)
        {
            return new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                EmployeeCode = dto.EmployeeCode,
                RoleId = dto.RoleId
            };
        }

        public static void MapUpdate(Employee entity, EmployeeUpdateDto dto)
        {
            if (dto.Name != null)
            {
                entity.Name = dto.Name;
            }
            if (dto.Email != null)
            {
                entity.Email = dto.Email;
            }
            if (dto.EmployeeCode != null)
            {
                entity.EmployeeCode = dto.EmployeeCode;
            }
            if (dto.RoleId.HasValue)
            {
                entity.RoleId = dto.RoleId.Value;
            }
            if(dto.IsActive.HasValue)
            {
                entity.IsActive = dto.IsActive.Value;
            }
        }

        public static EmployeeResponseDto ToResponseDto(Employee entity)
        {
            return new EmployeeResponseDto
            {
                Id = entity.Id,
                EmployeeCode = entity.EmployeeCode,
                Name = entity.Name,
                Email = entity.Email,
                IsActive = entity.IsActive,
                RoleId = entity.RoleId,
                RoleName = entity.Role?.Name ?? string.Empty,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
