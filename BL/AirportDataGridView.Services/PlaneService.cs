using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;
using AirportDataGridView.Services.Contracts;

namespace AirportDataGridView.Services
{
    public class PlaneService(IStorage storage) : IService
    {
        public Task Add(Plane item, CancellationToken cancellationToken = default)
        {
            storage.Add(item, cancellationToken);
            return Task.CompletedTask;
        }

        public Task Delete(Plane item, CancellationToken cancellationToken = default)
        {
            storage.Delete(item, cancellationToken);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default)
        {
            var allPLanes = await storage.GetAll(cancellationToken);
            return allPLanes;
        }

        public async Task<PlaneStatistics> Statistics(CancellationToken cancellationToken = default)
        {
            var statistics = await storage.Statistics(cancellationToken);
            return statistics;
        }

        public Task Update(Plane item, CancellationToken cancellationToken = default)
        {
            storage.Update(item, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
