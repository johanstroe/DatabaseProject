using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProjectStatusEntity
    {
        [Key]
        public int Id { get; set; }

        public string StatusName { get; set; } = null!;

        public ICollection<ProjectEntity> Projects { get; set; } = null!;
    }
}
