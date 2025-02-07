using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Repositories;


namespace Business.Services;

public class UserService(EmployeeRepository employeeRepository)
{
    private readonly EmployeeRepository _employeeRepository = employeeRepository;

    public async Task<bool> CreateUserAsync(CreateUserDto dto)
    {
        if (dto == null)
            return false;

        var existingUser = await _employeeRepository.ExistsAsync(x => x.Email == dto.Email);

        if (existingUser)
            return false;

        var newUser = EmployeeFactory.Create(dto.FirstName, dto.LastName, dto.Email);
        var result = await _employeeRepository.CreateAsync(newUser);
        return result != null;
    }



    public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync() ?? [];
    }

    public async Task<EmployeeEntity?> GetOneAsync(int userId)
    {
        return await _employeeRepository.GetOneAsync(p => p.UserId == userId);

    }

    public async Task<bool> UpdateAsync(EmployeeEntity employee)
    {
        if (employee == null)
            return false;

        var updatedProject = await _employeeRepository.UpdateAsync(p => p.UserId == employee.UserId, employee);

        return updatedProject != null!;
    }
    public async Task<bool> DeleteAsync(int userId)
    {
        if (userId <= 0)
            return false;

        return await _employeeRepository.DeleteAsync(p => p.UserId == userId);

    }


    public async Task<EM?> GetByIdAsync(int userId)
    {
        if (userId <= 0)
            return null;

        return await _employeeRepository.GetOneAsync(p => p.UserId == userId);
    }
}
