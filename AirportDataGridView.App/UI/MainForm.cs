using AirportDataGridView.Entities.Models;
using AirportDataGridView.Services.Contracts;

namespace AirportDataGridView.App.UI
{
    /// <summary>
    /// Класс основной формы приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IService planeService;
        private readonly CancellationTokenSource cancellationTokenSource = new();
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Конструктор для <see cref="MainForm"/>
        /// </summary>
        /// <param name="storage">Хранилище полетов</param>
        public MainForm(IService storage)
        {
            InitializeComponent();
            planeService = storage;
            CountStatistics();
        }

        private async Task InitDataAsync()
        {
            var existingPlanes = await planeService.GetAll();
            if (!existingPlanes.Any())
            {
                await planeService.Add(new Plane
                {
                    FlightNum = 1,
                    PlaneType = PlaneType.Boing,
                    Arrive = DateTime.Now.AddDays(2),
                    PassengersAmount = 10,
                    PassengersFee = 5,
                    CrewAmount = 3,
                    CrewFee = 10,
                    Markup = 15
                }, cancellationTokenSource.Token);
                await planeService.Add(new Plane
                {
                    FlightNum = 2,
                    PlaneType = PlaneType.Airbus,
                    Arrive = DateTime.Now.AddDays(3),
                    PassengersAmount = 20,
                    PassengersFee = 6,
                    CrewAmount = 4,
                    CrewFee = 15,
                    Markup = 20
                }, cancellationTokenSource.Token);
                await planeService.Add(new Plane
                {
                    FlightNum = 3,
                    PlaneType = PlaneType.Oak,
                    Arrive = DateTime.Now.AddDays(4),
                    PassengersAmount = 30,
                    PassengersFee = 7,
                    CrewAmount = 5,
                    CrewFee = 20,
                    Markup = 25
                }, cancellationTokenSource.Token);
            }
        }

        private void OnCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime date)
            {
                e.Value = date.ToString("dd.MM.yyyy HH:mm");
            }

            var col = dataGridView.Columns[e.ColumnIndex];

            if (col == ColumnRevenue)
            {
                var entry = (Plane)dataGridView.Rows[e.RowIndex].DataBoundItem;
                var result = (entry.PassengersAmount * entry.PassengersFee + entry.CrewAmount * entry.CrewFee);
                e.Value = result * (entry.Markup / 100) + result; // Добавление процента надбавки
            }
        }

        private void OnAddEntry(object? sender, EventArgs e)
        {
            var entryForm = new EntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                planeService.Add(entryForm.ResultEntry, cancellationTokenSource.Token);
                OnUpdate();
            }
        }

        private async void OnChangeEntry(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Plane plane)
            {
                var entryForm = new EntryForm(plane);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    await planeService.Update(entryForm.ResultEntry, cancellationTokenSource.Token);
                    OnUpdate();
                }
            }
        }

        private async void OnDeleteEntry(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Plane plane)
            {
                await planeService.Delete(plane, cancellationTokenSource.Token);
                OnUpdate();
            }
        }

        private async void CountStatistics()
        {
            var statistics = await planeService.Statistics(cancellationTokenSource.Token);

            toolStripStatusLabelArriving.Text = $"Прибывают: {statistics.AllFlights}";
            toolStripStatusLabelPassengers.Text = $"Пассажиры: {statistics.AllPassengers}";
            toolStripStatusLabelCrew.Text = $"Экипаж: {statistics.AllCrew}";
            toolStripStatusLabelRevenue.Text = $"Выручка: {statistics.AllRevenue}";
        }

        private void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            CountStatistics();
        }

        private async void OnFormLoad(object sender, EventArgs e)
        {
            await InitDataAsync();

            var planes = await planeService.GetAll(cancellationTokenSource.Token);
            bindingSource.DataSource = planes.ToList();

            dataGridView.AutoGenerateColumns = false;

            ColumnFlightNum.DataPropertyName = nameof(Plane.FlightNum);
            ColumnPlaneType.DataPropertyName = nameof(Plane.PlaneType);
            ColumnArrive.DataPropertyName = nameof(Plane.Arrive);
            ColumnPassengersAmount.DataPropertyName = nameof(Plane.PassengersAmount);
            ColumnPassengerFee.DataPropertyName = nameof(Plane.PassengersFee);
            ColumnCrewAmount.DataPropertyName = nameof(Plane.CrewAmount);
            ColumnCrewFee.DataPropertyName = nameof(Plane.CrewFee);
            ColumnMarkup.DataPropertyName = nameof(Plane.Markup);

            dataGridView.DataSource = bindingSource;
        }

        private async void OnUpdateClick(object sender, EventArgs e)
        {
            var planes = await planeService.GetAll(cancellationTokenSource.Token);
            bindingSource.DataSource = planes.ToList();
            OnUpdate();
        }
    }
}
