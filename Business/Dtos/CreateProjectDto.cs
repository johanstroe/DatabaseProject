

namespace Business.Dtos;

public class CreateProjectDto
{

    public string ProjectName { get; set; } = null!;

    
    public DateTime CreatedDate { get; set; }

   

    public int EmployeeId { get; set; }
    public int CustomerId { get; set; }
    public int StatusId { get; set; }
}
