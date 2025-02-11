using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Repositories;


namespace Business.Services;

public class CustomerService(CustomerRepository customerRepository) : ICustomerService
{
    private readonly CustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateUserAsync(CreateUserDto dto)
    {
        if (dto == null)
            return false;

        var existingUser = await _customerRepository.ExistsAsync(x => x.FirstName == dto.FirstName);

        if (existingUser)
            return false;

        var newUser = CustomerFactory.Create(dto.FirstName, dto.LastName, dto.Email);
        var result = await _customerRepository.CreateAsync(newUser);
        return result != null;
    }



    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync() ?? [];
    }

    public async Task<CustomerEntity?> GetOneAsync(int customerId)
    {
        return await _customerRepository.GetOneAsync(p => p.CustomerId == customerId);

    }

    public async Task<bool> UpdateAsync(CustomerEntity customer)
    {
        if (customer == null)
            return false;

        var updatedProject = await _customerRepository.UpdateAsync(p => p.CustomerId == customer.CustomerId, customer);

        return updatedProject != null!;
    }
    public async Task<bool> DeleteAsync(int customerId)
    {
        if (customerId <= 0)
            return false;

        return await _customerRepository.DeleteAsync(p => p.CustomerId == customerId);

    }


    public async Task<CustomerEntity?> GetByIdAsync(int customerId)
    {
        if (customerId <= 0)
            return null;

        return await _customerRepository.GetOneAsync(p => p.CustomerId == customerId);
    }
}
