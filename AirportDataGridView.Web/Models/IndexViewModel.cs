using AirportDataGridView.Entities.Models;

namespace AirportDataGridView.Web.Models;

/// <summary>
/// Модель представления для главной страницы
/// </summary>
public class IndexViewModel
{
    /// <summary>
    /// Коллекция рейсов для отображения на странице
    /// </summary>
    public IEnumerable<Plane> Planes { get; init; } = new List<Plane>();
    
    /// <summary>
    /// Объект статистики, содержащий агрегированные данные по рейсам
    /// </summary>
    public PlaneStatistics PlanesStatistics { get; init; } = new();
}