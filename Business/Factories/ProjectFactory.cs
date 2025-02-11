using Business.Dtos;
using Data.Entities;


namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create (string projectName, int id)
    {
        return new ProjectEntity
        {
            ProjectName = projectName,
            ProjectId = id,

        };
    }

    public static ProjectEntity Create(CreateProjectDto dto)
    {
        return new ProjectEntity
        {
            ProjectName = dto.ProjectName,
            StartDate = dto.CreatedDate,
            StatusId = dto.StatusId,
            EmployeeId = dto.EmployeeId,
            CustomerId = dto.CustomerId,
            
            
        };
    }
    public static CreateProjectDto Create(ProjectEntity entity)
    {
        return new CreateProjectDto
        {
            ProjectName = entity.ProjectName,
           

        };
    }

}
