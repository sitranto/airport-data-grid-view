using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;
using AirportDataGridView.Services.Contracts;

namespace AirportDataGridView.Services
{
    /// <summary>
    /// Сервисный слой для работы с данными о полетах
    /// </summary>
    public class PlaneService(IStorage storage) : IService
    {
        /// <summary>
        /// Добавление полета
        /// </summary>
        public Task Add(Plane item, CancellationToken cancellationToken = default)
        {
            storage.Add(item, cancellationToken);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Удаление полета
        /// </summary>
        public Task Delete(Plane item, CancellationToken cancellationToken = default)
        {
            storage.Delete(item, cancellationToken);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Возврат всех полетов
        /// </summary>
        public async Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default)
        {
            var allPLanes = await storage.GetAll(cancellationToken);
            return allPLanes;
        }

        /// <summary>
        /// Возврат статистики по полетам
        /// </summary>
        public async Task<PlaneStatistics> Statistics(CancellationToken cancellationToken = default)
        {
            var statistics = await storage.Statistics(cancellationToken);
            return statistics;
        }

        /// <summary>
        /// Обновление данных о полете
        /// </summary>
        public Task Update(Plane item, CancellationToken cancellationToken = default)
        {
            storage.Update(item, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
