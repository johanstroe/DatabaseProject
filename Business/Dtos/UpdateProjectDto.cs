

namespace Business.Dtos;

public class UpdateProjectDto
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime EndDate { get; set; }

    public decimal Price  { get; set; }

    public int ProductId { get; set; } 

    public int EmployeeId { get; set; }
    public int CustomerId { get; set; }
    public int StatusId { get; set; }

}




