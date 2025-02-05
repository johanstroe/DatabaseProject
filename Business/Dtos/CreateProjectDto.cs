using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class CreateProjectDto
    {

       // public CreateUserDto User { get; set; } = null!;

        public string ProjectName { get; set; } = null!;


        public string? Notes { get; set; }

        public decimal Budget { get; set; } = 0;

        public int UserId { get; set; }
    }
}
