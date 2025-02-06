
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int ProjectId { get; set; }

    [Required, MaxLength(50)]
    public string ProjectName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar (20)")]
    public string ProjectStatus { get; set; } = "Pågående"; // Pågående, Avslutat, Ej påbörjat

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;

    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    
}
