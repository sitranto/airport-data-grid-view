namespace AirportDataGridView.Entities.Models
{
    /// <summary>
    /// Статистика
    /// </summary>
    public class PlaneStatistics
    {
        /// <summary>
        /// Общее количество прибывающих рейсов
        /// </summary>
        public int AllFlights { get; set; }

        /// <summary>
        /// Общее количество пассажиров
        /// </summary>
        public int AllPassengers { get; set; }

        /// <summary>
        /// Общее количество экипажа
        /// </summary>
        public int AllCrew { get; set; }

        /// <summary>
        /// Общее количество выручки
        /// </summary>
        public float AllRevenue { get; set; }
    }
}
