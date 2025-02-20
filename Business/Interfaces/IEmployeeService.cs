using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IEmployeeService
{
    Task<bool> CreateUserAsync(CreateUserDto dto);
    Task<bool> DeleteAsync(int employeeId);
    Task<IEnumerable<EmployeeEntity>> GetAllAsync();
    Task<EmployeeEntity?> GetByIdAsync(int employeeId);
    Task<EmployeeEntity?> GetOneAsync(int employeeId);
    Task<bool> UpdateAsync(EmployeeEntity employee);
}