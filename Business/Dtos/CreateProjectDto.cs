

namespace Business.Dtos;

public class CreateProjectDto
{
    
    public string ProjectName { get; set; } = null!;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime EndDate { get; set; }

    public int ProductId {  get; set; }
    public int EmployeeId { get; set; }
    public int CustomerId { get; set; }
    public int StatusId { get; set; }


}
