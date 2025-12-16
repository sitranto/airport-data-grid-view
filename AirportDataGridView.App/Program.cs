using AirportDataGridView.App.UI;
using AirportDataGridView.Repository;
using AirportDataGridView.Services;
using Serilog;
using Serilog.Extensions.Logging;

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
            .WriteTo.Seq("http://localhost:5341",
                 apiKey: "fUAIjeUqzltPLEs2zuSx")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
            .CreateLogger();

            var loggerFactory = new SerilogLoggerFactory(Log.Logger, dispose: true);

            var storage = new DatabaseRepository();
            var service = new PlaneService(storage, loggerFactory);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}