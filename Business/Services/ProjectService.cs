

using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;
    private readonly UserService _userService;

    public ProjectService(ProjectRepository projectRepository, UserService userService)
    {
        _projectRepository = projectRepository;
        _userService = userService;
        
    }

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

    public async Task<IEnumerable<ProjectEntity>> GetOneAsync(string getOne)
    {
        return await _projectRepository.GetOneAsync(p => p.getOne == getOne) ?? [];
        
    }

    public async Task<bool> UpdateAsync(ProjectEntity project)
    {
        _context.Projects.Update(project);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteAsync(int projectId) 
    { 
    
    }


    public async Task<ProjectEntity?> GetByIdAsync(int projectId)
    {
       
    }

    
}
