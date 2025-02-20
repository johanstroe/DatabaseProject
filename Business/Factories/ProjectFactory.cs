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

    public static ProjectEntity Create(UpdateProjectDto dto)
    {
        return new ProjectEntity
        {
            ProjectId = dto.ProjectId,
            ProjectName = dto.ProjectName,
            StartDate = dto.CreatedDate,
            EndDate = dto.EndDate,
            ProductId = dto.ProductId,
            StatusId = dto.StatusId,
            EmployeeId = dto.EmployeeId,
            CustomerId = dto.CustomerId
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
            ProductId = entity.Product.Id,
            ProductPrice = entity.Product.Price,
            EmployeeEmail = entity.Employee.Email,
            EmployeeId = entity.EmployeeId,
            CustomerId = entity.CustomerId,
            StatusId = entity.StatusId
          
        };
    }

    public static UpdateProjectDto CreateUpdateDto(ProjectsDto dto)
    {
        return new UpdateProjectDto
        {
            ProjectId = dto.ProjectId,
            ProjectName = dto.ProjectName,
            CreatedDate = dto.StartDate,
            ProductId = dto.ProductId,
            StatusId = dto.StatusId,
            EmployeeId = dto.EmployeeId,
            CustomerId = dto.CustomerId,
            ProductName = dto.ProductName,
            Name = dto.Name
            
        };
    }

}
