namespace AirportDataGridView.Web.Models;

/// <summary>
/// Модель представления для страницы отображения ошибок
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Идентификатор запроса
    /// </summary>
    public string? RequestId { get; init; }

    /// <summary>
    /// Указывает следовать ли отображать идентификатор запроса на странице ошибки
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}