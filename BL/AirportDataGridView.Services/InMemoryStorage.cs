using AirportDataGridView.Entities.Models;
using AirportDataGridView.Services.Contracts;

namespace AirportDataGridView.Services
{
    /// <summary>
    /// Класс inMemory хранилища в виде списка <see cref="List{Plane}"/> для 
    /// объектов класса <see cref="Plane"/>
    /// </summary>
    public class InMemoryStorage : IStorage<Plane>
    {
        private List<Plane> Planes { get; } =
            [
                new Plane
                {
                    FlightNum = 1,
                    PlaneType = PlaneType.Boing,
                    Arrive = DateTime.Now.AddDays(2),
                    PassengersAmount = 10,
                    PassengersFee = 5,
                    CrewAmount = 3,
                    CrewFee = 10,
                    Markup = 15
                },
                new Plane
                {
                    FlightNum = 2,
                    PlaneType = PlaneType.Airbus,
                    Arrive = DateTime.Now.AddDays(3),
                    PassengersAmount = 20,
                    PassengersFee = 6,
                    CrewAmount = 4,
                    CrewFee = 15,
                    Markup = 20
                },
                new Plane
                {
                    FlightNum = 3,
                    PlaneType = PlaneType.Oak,
                    Arrive = DateTime.Now.AddDays(4),
                    PassengersAmount = 30,
                    PassengersFee = 7,
                    CrewAmount = 5,
                    CrewFee = 20,
                    Markup = 25
                },
            ];

        /// <summary>
        /// <inheritdoc cref="IStorage{T}.Add(T, CancellationToken)"/>
        /// </summary>
        public Task Add(Plane plane, CancellationToken cancellationToken = default)
        {
            Planes.Add(plane);
            return Task.CompletedTask;
        }

        /// <summary>
        /// <inheritdoc cref="IStorage{T}.Delete(T, CancellationToken)"/>
        /// </summary>
        public Task Delete(Plane plane, CancellationToken cancellationToken = default)
        {
            Planes.Remove(plane);
            return Task.CompletedTask;
        }

        /// <summary>
        /// <inheritdoc cref="IStorage{T}.GetAll(CancellationToken)"/>
        /// </summary>
        public Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default)
        {
            var res = Planes.AsEnumerable();
            return Task.FromResult(res);
        }
    }
}
