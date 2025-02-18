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
            EndDate = dto.EndDate,
            ProductId = dto.ProductId,
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
            CreatedDate = entity.StartDate,
            CustomerId = entity.CustomerId,
            StatusId = entity.StatusId,
            EmployeeId = entity.EmployeeId

        };
    }

    public static ProjectsDto Read (ProjectEntity entity)
    {
        return new ProjectsDto
        {
            ProjectId = entity.ProjectId,
            ProjectName = entity.ProjectName,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            StatusName = entity.Status.StatusName,
            ProductName = entity.Product.ProductName,
            ProductPrice = entity.Product.Price,
            EmployeeEmail = entity.Employee.Email,
            
        };
    }

}
