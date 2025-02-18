
using System.ComponentModel.DataAnnotations;


namespace Data.Entities;

public class ProjectStatusEntity
{
    [Key]
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = null!;

}
