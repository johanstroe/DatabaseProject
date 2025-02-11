using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<bool> CreateUserAsync(CreateUserDto dto);
    Task<bool> DeleteAsync(int customerId);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity?> GetByIdAsync(int customerId);
    Task<CustomerEntity?> GetOneAsync(int customerId);
    Task<bool> UpdateAsync(CustomerEntity customer);
}