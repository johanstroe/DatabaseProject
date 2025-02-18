

namespace Business.Dtos;

public class ProjectsDto
{
 
    public int ProjectId { get; set; }


    public string ProjectName { get; set; } = null!;

    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; }

    public string ProjectType { get; set; } = null!;

    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public string EmployeeEmail { get; set; } = null!;
}
