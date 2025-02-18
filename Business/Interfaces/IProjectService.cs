using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(CreateProjectDto dto);
    Task<bool> DeleteAsync(int projectId);
    Task<IEnumerable<ProjectsDto>> GetAllAsync();
    Task<ProjectEntity?> GetByIdAsync(int projectId);
    Task<ProjectEntity?> GetOneAsync(int projectId);
    Task<bool> UpdateAsync(ProjectEntity project);
}