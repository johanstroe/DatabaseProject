using Business.Interfaces;
using Data.Entities;
using Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class StatusService : IStatusService
    {
        private readonly ProjectStatusRepository _statusRepository;

        public StatusService(ProjectStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<List<ProjectStatusEntity>> GetAllStatusesAsync()
        {
            var statuses = await _statusRepository.GetAllAsync() ?? Enumerable.Empty<ProjectStatusEntity>(); //Om status är null ersätts det med en tom lista
            return statuses.ToList();
        }

    }
}
