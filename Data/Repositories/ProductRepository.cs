

using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;


public class ProductRepository(AppDbContext context) : BaseRepository<ProductEntity>(context)
{  
}
