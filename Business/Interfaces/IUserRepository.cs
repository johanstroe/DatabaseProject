
using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IUserRepository 
{
    Task<UserEntity> CreateUserAsync(UserRegistrationForm registrationForm);
    Task<UserEntity> GetUsersAsync();
    Task<UserEntity> GetUserByIdAsync(int id);

    Task<UserEntity> GetUserByEmailAsync(string email);
    Task<UserEntity> UpdateUserAsync(int id, UserUpdateForm updateForm);
    Task<UserEntity> DeleteUserAsync(int id);
    
}
