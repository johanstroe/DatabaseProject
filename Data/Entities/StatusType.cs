

using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusType
{
    [Key]
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;
}