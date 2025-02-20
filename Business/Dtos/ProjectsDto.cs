

using Data.Entities;

namespace Business.Dtos;

public class ProjectsDto
{
 
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = null!;

    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    

    public int StatusId { get; set; }
    public string StatusName { get; set; } = null!;

    
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
   

    public int EmployeeId { get; set; }
    public string EmployeeEmail { get; set; } = null!;
    public string EmployeeName { get; set; } = null!;

   

    public int CustomerId { get; set; }
    public string Name { get; set; } = null!;
}
