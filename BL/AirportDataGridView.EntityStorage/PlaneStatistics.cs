namespace AirportDataGridView.EntityManager
{
    /// <summary>
    /// Класс статистики
    /// </summary>
    public class PlaneStatistics
    {
        /// <summary>
        /// Свойство общего количества прибывающих рейсов
        /// </summary>
        public int AllFlights { get; set; }
        
        /// <summary>
        /// Свойство общего количества пассажиров
        /// </summary>
        public int AllPassengers { get; set; }

        /// <summary>
        /// Свойство общего количества экипажа
        /// </summary>
        public int AllCrew { get; set; }

        /// <summary>
        /// Свойство общего количества выручки
        /// </summary>
        public float AllRevenue { get; set; }
    }
}
