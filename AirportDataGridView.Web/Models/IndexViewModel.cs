using AirportDataGridView.Entities.Models;

namespace AirportDataGridView.Web.Models;

public class IndexViewModel
{
    public IEnumerable<Plane> Planes { get; set; } = new List<Plane>();
    
    public PlaneStatistics PlanesStatistics { get; set; } = new();
}