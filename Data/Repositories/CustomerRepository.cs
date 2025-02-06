using Data.Contexts;
using Data.Entities;


namespace Data.Repositories;

public class CustomerRepository : BaseRepository<CustomerEntity>
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
