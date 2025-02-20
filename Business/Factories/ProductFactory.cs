

using Data.Entities;

namespace Business.Factories;

public static class ProductFactory
{
    public static ProductEntity Create(string productName, decimal price)
    {
        return new ProductEntity
        {
            ProductName = productName,
            Price = price

        };
    }
}
