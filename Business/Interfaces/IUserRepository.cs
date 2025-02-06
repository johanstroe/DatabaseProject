
using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IUserRepository 
{
    Task<EmployeeEntity> CreateUserAsync(UserRegistrationForm registrationForm);
    Task<EmployeeEntity> GetUsersAsync();
    Task<EmployeeEntity> GetUserByIdAsync(int id);

    Task<EmployeeEntity> GetUserByEmailAsync(string email);
    Task<EmployeeEntity> UpdateUserAsync(int id, UserUpdateForm updateForm);
    Task<EmployeeEntity> DeleteUserAsync(int id);
    
}
