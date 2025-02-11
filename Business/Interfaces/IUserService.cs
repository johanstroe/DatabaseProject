using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDto dto);
        Task<bool> DeleteAsync(int userId);
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();
        Task<EmployeeEntity?> GetByIdAsync(int userId);
        Task<EmployeeEntity?> GetOneAsync(int userId);
        Task<bool> UpdateAsync(EmployeeEntity employee);
    }
}