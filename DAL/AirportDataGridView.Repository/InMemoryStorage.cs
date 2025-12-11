using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;

namespace AirportDataGridView.Repository
{
    /// <summary>
    /// Класс inMemory хранилища в виде списка <see cref="List{Plane}"/> для 
    /// объектов класса <see cref="Plane"/>
    /// </summary>
    public class InMemoryStorage : IStorage
    {
        private List<Plane> Planes { get; } = [];

        Task IStorage.Add(Plane plane, CancellationToken cancellationToken)
        {
            Planes.Add(plane);
            return Task.CompletedTask;
        }

        Task IStorage.Update(Plane plane, CancellationToken cancellationToken)
        {
            var planeToEdit = Planes.FirstOrDefault(x => x.Id == plane.Id);

            if (planeToEdit != null)
            {
                planeToEdit.FlightNum = plane.FlightNum;
                planeToEdit.PlaneType = plane.PlaneType;
                planeToEdit.Arrive = plane.Arrive;
                planeToEdit.PassengersAmount = plane.PassengersAmount;
                planeToEdit.PassengersFee = plane.PassengersFee;
                planeToEdit.CrewAmount = plane.CrewAmount;
                planeToEdit.CrewFee = plane.CrewFee;
                planeToEdit.Markup = plane.Markup;
            }

            return Task.CompletedTask;
        }

        Task IStorage.Delete(Plane plane, CancellationToken cancellationToken)
        {
            Planes.Remove(plane);
            return Task.CompletedTask;
        }

        Task<IEnumerable<Plane>> IStorage.GetAll(CancellationToken cancellationToken)
        {
            var res = Planes.AsEnumerable();
            return Task.FromResult(res);
        }
    }
}
