using AirportDataGridView.Entities.Models;
using AirportDataGridView.EntityManager;
using AirportDataGridView.Services.Contracts;

namespace AirportDataGridView.App.UI
{
    /// <summary>
    /// Класс основной формы приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly PlaneManager planeManager;
        private readonly CancellationTokenSource cancellationTokenSource = new();
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Конструктор для <see cref="MainForm"/>
        /// </summary>
        /// <param name="storage">Хранилище полетов</param>
        public MainForm(IStorage<Plane> storage)
        {
            InitializeComponent();
            planeManager = new(storage);
            CountStatistics();
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
                planeManager.Add(entryForm.ResultEntry, cancellationTokenSource.Token);
                OnUpdate();
            }
        }

        private void OnChangeEntry(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Plane plane)
            {
                var entryForm = new EntryForm(plane);
                entryForm.ShowDialog();
                OnUpdate();
            }
        }

        private async void OnDeleteEntry(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Plane plane)
            {
                await planeManager.Delete(plane, cancellationTokenSource.Token);
                OnUpdate();
            }
        }

        private async void CountStatistics()
        {
            var statistics = await planeManager.GetStatistics(cancellationTokenSource.Token);

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
            bindingSource.DataSource = await planeManager.GetAll(cancellationTokenSource.Token);
            dataGridView.DataSource = bindingSource;

            dataGridView.AutoGenerateColumns = false;

            ColumnFlightNum.DataPropertyName = nameof(Plane.FlightNum);
            ColumnPlaneType.DataPropertyName = nameof(Plane.PlaneType);
            ColumnArrive.DataPropertyName = nameof(Plane.Arrive);
            ColumnPassengersAmount.DataPropertyName = nameof(Plane.PassengersAmount);
            ColumnPassengerFee.DataPropertyName = nameof(Plane.PassengersFee);
            ColumnCrewAmount.DataPropertyName = nameof(Plane.CrewAmount);
            ColumnCrewFee.DataPropertyName = nameof(Plane.CrewFee);
            ColumnMarkup.DataPropertyName = nameof(Plane.Markup);
        }
    }
}
