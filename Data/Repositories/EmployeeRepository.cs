using Data.Contexts;
using Data.Entities;


namespace Data.Repositories;

public class EmployeeRepository(AppDbContext context) : BaseRepository<EmployeeEntity>(context)
{
}
