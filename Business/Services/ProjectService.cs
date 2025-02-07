

using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository, UserService userService)
{
    private readonly ProjectRepository _projectRepository = projectRepository;
    private readonly UserService _userService = userService;

    public async Task<bool> CreateProjectAsync(CreateProjectDto dto)
    {
        if (dto == null) 
            return false;

        var project = await _projectRepository.ExistsAsync(x => x.ProjectName == dto.ProjectName);
        
        if (project)
            return false;

        // var userId = await _userService.CreateOrGetUserAsync(form.User.FirstName, form.User.LastName, form.User.Email);

        // var result = await _projectRepository.CreateAsync(ProjectFactory.Create(form.ProjectName, userId));
        //return result != null;

        var result = await _projectRepository.CreateAsync(ProjectFactory.Create(dto));
        return result != null;
    }

  

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync() ?? [];
    }

    public async Task<ProjectEntity?> GetOneAsync(int projectId)
    {
        return await _projectRepository.GetOneAsync(p => p.ProjectId == projectId);
        
    }

    public async Task<bool> UpdateAsync(ProjectEntity project)
    {
        if (project == null)
            return false;
        
        var updatedProject = await _projectRepository.UpdateAsync(p => p.ProjectId == project.ProjectId, project);

        return updatedProject != null!;
    }   
    public async Task<bool> DeleteAsync(int projectId) 
    { 
     if (projectId <= 0)
            return false;

     return await _projectRepository.DeleteAsync(p => p.ProjectId == projectId);

    }


    public async Task<ProjectEntity?> GetByIdAsync(int projectId)
    {
        if (projectId <= 0)
            return null;

        return await _projectRepository.GetOneAsync(p => p.ProjectId == projectId);
    }

    
}
