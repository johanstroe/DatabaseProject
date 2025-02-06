

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar (50)")]
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }

    public ICollection<ProjectEntity> Projects { get; set; } = null!;
}