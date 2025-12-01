using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;
using AirportDataGridView.Services.Contracts;
using Serilog;
using System.Diagnostics;

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
        public async Task Add(Plane item, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Add(item, cancellationToken);
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error($"PlaneService.Add не выполнен с ошибкой: {ex.Message}");
            }
            finally
            {
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("PlaneService.Add выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Удаление полета
        /// </summary>
        public async Task Delete(Plane item, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Delete(item, cancellationToken);
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error($"PlaneService.Delete не выполнен с ошибкой: {ex.Message}");
            }
            finally
            {
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("PlaneService.Delete выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Возврат всех полетов
        /// </summary>
        public async Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var allPLanes = await storage.GetAll(cancellationToken);
                return allPLanes;
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error($"PlaneService.GetAll не выполнен с ошибкой: {ex.Message}");
                throw;
            }
            finally
            {
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("PlaneService.GetAll выполнен за {ms:F6} мс", ms);
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
                var statistics = await storage.Statistics(cancellationToken);
                return statistics;
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error($"PlaneService.Statistics не выполнен с ошибкой: {ex.Message}");
                throw;
            }
            finally
            {
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("PlaneService.Statistics выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Обновление данных о полете
        /// </summary>
        public async Task Update(Plane item, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Update(item, cancellationToken);
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error($"PlaneService.Update не выполнен с ошибкой: {ex.Message}");
                throw;
            }
            finally
            {
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("PlaneService.Update выполнен за {ms:F6} мс", ms);
            }
        }
    }
}
