using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(AppDbContext context) : BaseRepository<ProjectEntity>(context)
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var entities = 
            await _context.Projects
            .Include(x => x.Status)
            .Include(x => x.Product)
            .Include(x => x.Employee)
            .ToListAsync();
        return entities;
    }
}

