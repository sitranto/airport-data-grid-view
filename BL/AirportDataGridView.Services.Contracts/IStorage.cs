namespace AirportDataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс inMemory хранилища сущностей. Определяет
    /// методы для взаимодействия с хранилищем
    /// </summary>
    /// <typeparam name="T">Референс сущности хранилища</typeparam>
    public interface IStorage<T>
    {
        /// <summary>
        /// Метод получения всех объектов хранилища 
        /// </summary>
        public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);

        /// <summary>
        /// Метод добавления объекта в хранилище
        /// </summary>
        public Task Add(T item, CancellationToken cancellationToken = default);

        /// <summary>
        /// Метод удаления объекта в хранилище
        /// </summary>
        public Task Delete(T item, CancellationToken cancellationToken = default);
    }
}
