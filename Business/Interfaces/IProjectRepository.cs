

using Data.Entities;


namespace Business.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectEntity>> GetAllAsync();
    Task<ProjectEntity?> GetByIdAsync(int projectId);
    Task<bool> CreateAsync(ProjectEntity project);
    Task<bool> UpdateAsync(ProjectEntity project);
    Task<bool> DeleteAsync(int projectId);
   
}
