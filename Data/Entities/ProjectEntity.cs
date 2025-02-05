
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int ProjectId { get; set; }

    [Required, MaxLength(20)]
    public string ProjectName { get; set; } = null!;

    [Required]
    public string Status { get; set; } = "Pågående"; // Pågående, Avslutat, Ej påbörjat

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

   

    [ForeignKey("ResponsibleUser")]
    public int ResponsibleUserId { get; set; } // Koppling till ansvarig användare
    public UserEntity ResponsibleUser { get; set; } = null!;

    [MaxLength(500)]
    public string? Notes { get; set; }

    public decimal Budget { get; set; } = 0;


}
