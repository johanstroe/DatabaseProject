using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateUserAsync(ProductsDto dto);
        Task<bool> DeleteAsync(int Id);
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetByIdAsync(int Id);
        Task<ProductEntity?> GetOneAsync(int Id);
        Task<bool> UpdateAsync(ProductEntity product);
    }
}