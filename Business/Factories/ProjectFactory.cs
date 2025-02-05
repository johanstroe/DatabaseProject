using Business.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectEntity Create (string projectName, int id)
        {
            return new ProjectEntity
            {
                ProjectName = projectName,
                ResponsibleUserId = id,

            };
        }

        public static ProjectEntity Create(CreateProjectDto dto)
        {
            return new ProjectEntity
            {
                ProjectName = dto.ProjectName,
                Budget = dto.Budget,
                Notes = dto.Notes,
                ResponsibleUserId = dto.UserId,
            };
        }
    }
}
