using Data.Contexts;
using Data.Entities;


namespace Data.Repositories;

public class ProjectStatusRepository(AppDbContext context) : BaseRepository<ProjectStatusEntity>(context)
{
}

