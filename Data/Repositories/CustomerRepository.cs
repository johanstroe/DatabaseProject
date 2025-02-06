using Data.Contexts;
using Data.Entities;


namespace Data.Repositories;

public class CustomerRepository(AppDbContext context) : BaseRepository<CustomerEntity>(context)
{
}
