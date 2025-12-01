using AirportDataGridView.App.UI;
using AirportDataGridView.Repository;
using AirportDataGridView.Services;
using Serilog;

namespace AirportDataGridView.App
{
    /// <summary>
    /// Класс программы
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Debug()
            .WriteTo.Seq("http://localhost:5341",
                 apiKey: "fUAIjeUqzltPLEs2zuSx")
            .CreateLogger();

            Log.Debug("Тестовый лог в Debug окне");

            var storage = new InMemoryStorage();
            var service = new PlaneService(storage);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}