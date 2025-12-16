using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;
using AirportDataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Numerics;

namespace AirportDataGridView.Services
{
    /// <summary>
    /// Сервисный слой для работы с данными о полетах
    /// </summary>
    public class PlaneService(IStorage storage, ILoggerFactory loggerFactory) : IService
    {
        private readonly ILogger<PlaneService> logger = loggerFactory.CreateLogger<PlaneService>();

        /// <summary>
        /// Добавление полета
        /// </summary>
        public async Task Add(Entities.Models.Plane item, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Add(item, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("PlaneService.Add выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Удаление полета
        /// </summary>
        public async Task Delete(Entities.Models.Plane item, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Delete(item, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("PlaneService.Delete выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Возврат всех полетов
        /// </summary>
        public async Task<IEnumerable<Entities.Models.Plane>> GetAll(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var allPLanes = await storage.GetAll(cancellationToken);
                return allPLanes;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("PlaneService.GetAll выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Возврат статистики по полетам
        /// </summary>
        public async Task<PlaneStatistics> Statistics(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var planes = await storage.GetAll(cancellationToken);

                return new PlaneStatistics()
                {
                    AllFlights = planes.Count(),
                    AllPassengers = planes.Sum(x => x.PassengersAmount),
                    AllCrew = planes.Sum(x => x.CrewAmount),
                    AllRevenue = planes.Sum(x =>
                    {
                        var result = (x.PassengersAmount * x.PassengersFee + x.CrewAmount * x.CrewFee);
                        return result * (x.Markup / 100) + result; // Добавление процента надбавки
                    })
                };
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("PlaneService.Statistics выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Обновление данных о полете
        /// </summary>
        public async Task Update(Entities.Models.Plane item, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Update(item, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("PlaneService.Update выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }
    }
}
