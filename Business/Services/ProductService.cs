using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Repositories;


namespace Business.Services;

public class ProductService(ProductRepository productRepository) : IProductService
{
    private readonly ProductRepository _productRepository = productRepository;

    public async Task<bool> CreateUserAsync(ProductsDto dto)
    {
        if (dto == null)
            return false;

        var existingUser = await _productRepository.ExistsAsync(x => x.ProductName == dto.ProductName);

        if (existingUser)
            return false;

        var newUser = ProductFactory.Create(dto.ProductName, dto.Price);
        var result = await _productRepository.CreateAsync(newUser);
        return result != null;
    }



    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync() ?? [];
    }

    public async Task<ProductEntity?> GetOneAsync(int Id)
    {
        return await _productRepository.GetOneAsync(p => p.Id == Id);

    }

    public async Task<bool> UpdateAsync(ProductEntity product)
    {
        if (product == null)
            return false;

        var updatedProject = await _productRepository.UpdateAsync(p => p.Id == product.Id, product);

        return updatedProject != null!;
    }
    public async Task<bool> DeleteAsync(int Id)
    {
        if (Id <= 0)
            return false;

        return await _productRepository.DeleteAsync(p => p.Id == Id);

    }


    public async Task<ProductEntity?> GetByIdAsync(int Id)
    {
        if (Id <= 0)
            return null;

        return await _productRepository.GetOneAsync(p => p.Id == Id);
    }
}
