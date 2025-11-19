using AirportDataGridView.Entities.Models;
using AirportDataGridView.Services.Contracts;

namespace AirportDataGridView.EntityManager
{
    /// <summary>
    /// Класс управления хранилищем самолетов <see cref="IStorage{Plane}"/>
    /// </summary>
    /// <param name="storage">Хранилище, управляемое данным классом</param>
    public class PlaneManager(IStorage<Plane> storage)
    {
        private IStorage<Plane> Storage { get; } = storage;

        /// <summary>
        /// <inheritdoc cref="IStorage{T}.GetAll(CancellationToken)"/>
        /// </summary>
        public Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default) =>
            Storage.GetAll(cancellationToken);

        /// <summary>
        /// <inheritdoc cref="IStorage{T}.Add(T, CancellationToken)"/>
        /// </summary>
        public Task Add(Plane plane, CancellationToken cancellationToken = default) =>
            Storage.Add(plane, cancellationToken);

        /// <summary>
        /// <inheritdoc cref="IStorage{T}.Delete(T, CancellationToken)"/>
        /// </summary>
        public Task Delete(Plane plane, CancellationToken cancellationToken = default) =>
            Storage.Delete(plane, cancellationToken);

        /// <summary>
        /// Метод получения статистики всех сущностей в хранилище
        /// </summary>
        public async Task<PlaneStatistics> GetStatistics(CancellationToken cancellationToken = default)
        {
            var planes = await GetAll(cancellationToken);

            var allFlights = planes.Count();
            var allPassengers = planes.Sum(x => x.PassengersAmount);
            var allCrew = planes.Sum(x => x.CrewAmount);
            var allRevenue = planes.Sum(x =>
            {
                var result = (x.PassengersAmount * x.PassengersFee + x.CrewAmount * x.CrewFee);
                return result * (x.Markup / 100) + result; // Добавление процента надбавки
            });

            return new PlaneStatistics()
            {
                AllFlights = allFlights,
                AllPassengers = allPassengers,
                AllCrew = allCrew,
                AllRevenue = allRevenue
            };
        }
    }
}
