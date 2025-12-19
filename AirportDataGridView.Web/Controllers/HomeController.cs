using System.Diagnostics;
using AirportDataGridView.Entities.Models;
using AirportDataGridView.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using AirportDataGridView.Web.Models;

namespace AirportDataGridView.Web.Controllers;

/// <summary>
/// Контроллер для управления рейсами
/// </summary>
public class HomeController(IService service) : Controller
{
    private IService PlanesService => service;
    
    /// <summary>
    /// Отображает главную страницу со списком всех рейсов и статистикой
    /// </summary>
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
    
    /// <summary>
    /// Отображает форму для создания нового рейса
    /// </summary>
    [HttpGet]
    public IActionResult Create()
    {
        return View(new PlaneSaveViewModel());
    }

    /// <summary>
    /// Обрабатывает отправку формы создания нового рейса
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(PlaneSaveViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var plane = new Plane
        {
            Id = model.Id,
            PlaneType = model.PlaneType,
            FlightNum = model.FlightNum,
            Arrive = model.Arrive,
            PassengersAmount = model.PassengersAmount,
            PassengersFee = model.PassengersFee,
            CrewAmount = model.CrewAmount,
            CrewFee = model.CrewFee,
            Markup = model.Markup
        };
            
        await PlanesService.Add(plane, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Отображает форму для редактирования существующего рейса по его идентификатору
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var planes = await PlanesService.GetAll(cancellationToken);
        var planeToEdit = planes.FirstOrDefault(x => x.Id == id);

        if (planeToEdit == null)
        {
            return NotFound();
        }

        var planeSaveViewModel = new PlaneSaveViewModel
        {
            Id = planeToEdit.Id,
            FlightNum = planeToEdit.FlightNum,
            PlaneType = planeToEdit.PlaneType,
            Arrive = planeToEdit.Arrive,
            PassengersAmount = planeToEdit.PassengersAmount,
            PassengersFee = planeToEdit.PassengersFee,
            CrewAmount = planeToEdit.CrewAmount,
            CrewFee = planeToEdit.CrewFee,
            Markup = planeToEdit.Markup
        };
        
        return View(planeSaveViewModel);
    }

    /// <summary>
    /// Обрабатывает отправку формы редактирования рейса
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Edit(PlaneSaveViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var planes = await PlanesService.GetAll(cancellationToken);
        var planeToEdit = planes.FirstOrDefault(x => x.Id == model.Id); 
        
        if (planeToEdit == null)
        {
            return NotFound();
        }
        
        planeToEdit.FlightNum = model.FlightNum;
        planeToEdit.PlaneType = model.PlaneType;
        planeToEdit.Arrive = model.Arrive;
        planeToEdit.PassengersAmount = model.PassengersAmount;
        planeToEdit.PassengersFee = model.PassengersFee;
        planeToEdit.CrewAmount = model.CrewAmount;
        planeToEdit.CrewFee = model.CrewFee;
        planeToEdit.Markup = model.Markup;
        
        await PlanesService.Update(planeToEdit, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Отображает страницу подтверждения удаления рейса
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var planes = await PlanesService.GetAll(cancellationToken);
        var planeToDelete = planes.FirstOrDefault(x => x.Id == id);

        if (planeToDelete == null)
        {
            return NotFound();
        }
        
        return View(planeToDelete);
    }

    /// <summary>
    /// Выполняет удаление рейса после подтверждения
    /// </summary>
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
    {
        var planes = await PlanesService.GetAll(cancellationToken);
        var planeToDelete = planes.FirstOrDefault(x => x.Id == id);

        if (planeToDelete == null)
        {
            return NotFound();
        }
        
        await PlanesService.Delete(planeToDelete, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Отображает страницу "Политика конфиденциальности".
    /// </summary>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Отображает страницу ошибки с информацией о текущем запросе.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}