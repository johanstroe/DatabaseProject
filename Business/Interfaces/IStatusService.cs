using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<List<ProjectStatusEntity>> GetAllStatusesAsync();
    }
}
