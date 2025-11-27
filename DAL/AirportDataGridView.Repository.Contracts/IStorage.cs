using AirportDataGridView.Entities.Models;

namespace AirportDataGridView.Repository.Contracts
{
    /// <summary>
    /// Интерфейс хранилища сущностей
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Метод получения всех объектов хранилища 
        /// </summary>
        Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default);

        /// <summary>
        /// Метод добавления объекта в хранилище
        /// </summary>
        Task Add(Plane item, CancellationToken cancellationToken = default);

        /// <summary>
        /// Метод обновления объекта в хранилище
        /// </summary>
        Task Update(Plane item, CancellationToken cancellationToken = default);

        /// <summary>
        /// Метод удаления объекта в хранилище
        /// </summary>
        Task Delete(Plane item, CancellationToken cancellationToken = default);

        /// <summary>
        /// Метод получения статистики объектов в хранилище
        /// </summary>
        Task<PlaneStatistics> Statistics(CancellationToken cancellationToken = default);
    }
}
