using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Repositories;
using System.Diagnostics;

namespace Business.Services;

public class UserService(EmployeeRepository userRepository)
{
    private readonly EmployeeRepository _userRepository = userRepository;



    public async Task<int> CreateOrGetUserAsync(string firstName, string lastName, string email)
    {
        try
        {
            var user = await _userRepository.GetOneAsync(x => x.Email == email);
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                var createdUser = await _userRepository.CreateAsync(UserFactory.Create(firstName, lastName, email));
                if (createdUser != null)
                    return createdUser.Id;
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex.Message);
        }
        return 0;


    }

    public async Task<IResult> CreateUserAsync(UserRegistrationForm registrationForm)
    {
        if (registrationForm == null)
        {
            return Result.BadRequest("Invalid registration form");
        }

        if (await _userRepository.ExistsAsync(x => x.Email == registrationForm.Email))
        {
            return Result.AlreadyExists("Email is already registered.");
        }

        try
        {
            var userEntity = new EmployeeEntity
            {
                FirstName = registrationForm.FirstName,
                LastName = registrationForm.LastName,
                Email = registrationForm.Email,
            };

     
            var result = await _userRepository.CreateAsync(userEntity);
            return result != null ? Result.Ok() : Result.Error("Unable to create user.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetUsersAsync()
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            return Result<IEnumerable<EmployeeEntity>>.Ok(users);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error("Failed to retrieve users.");
        }
    }

    public async Task<IResult> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await _userRepository.GetOneAsync(x => x.Id == id);
            return user != null ? Result<EmployeeEntity>.Ok(user) : Result.NotFound("User not found.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error("Failed to retrieve user.");
        }
    }

    public async Task<IResult> GetUserByEmailAsync(string email)
    {
        try
        {
            var user = await _userRepository.GetOneAsync(x => x.Email == email);
            return user != null ? Result<EmployeeEntity>.Ok(user) : Result.NotFound("User not found.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error("Failed to retrieve user.");
        }
    }

    public async Task<IResult> UpdateUserAsync(int id, UserUpdateForm updateForm)
    {
        try
        {
            var user = await _userRepository.GetOneAsync(x => x.Id == id);
            if (user == null)
                return Result.NotFound("User not found.");

            user.FirstName = updateForm.FirstName ?? user.FirstName;
            user.LastName = updateForm.LastName ?? user.LastName;
            user.Email = updateForm.Email ?? user.Email;

            var result = await _userRepository.UpdateAsync(x => x.Id == id, user);
            return result != null ? Result.Ok() : Result.Error("Unable to update user.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error("Failed to update user.");
        }
    }

    public async Task<IResult> DeleteUserAsync(int id)
    {
        try
        {
            var result = await _userRepository.DeleteAsync(x => x.Id == id);
            return result ? Result.Ok() : Result.NotFound("User not found.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error("Failed to delete user.");
        }
    }
}
