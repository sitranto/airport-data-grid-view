using System.Diagnostics;
using AirportDataGridView.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using AirportDataGridView.Web.Models;

namespace AirportDataGridView.Web.Controllers;

public class HomeController(IService service) : Controller
{
    public IService PlanesService => service;
    
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var planes = await PlanesService.GetAll(cancellationToken);
        var statistics = await service.Statistics(cancellationToken);

        var viewModel = new IndexViewModel
        {
            Planes = planes,
            PlanesStatistics = statistics
        };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}