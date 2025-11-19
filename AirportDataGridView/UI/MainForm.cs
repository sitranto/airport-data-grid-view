using AirportDataGridView.Entities.Models;

namespace AirportDataGridView.App.UI
{
    /// <summary>
    /// Класс основной формы приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly List<Entry> entries = []; 
        private readonly BindingSource bindingSource = new BindingSource();

        /// <summary>
        /// Конструктор для <see cref="MainForm"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            entries = 
                [
                    new Entry 
                    {
                        FlightNum = 1,
                        PlaneType = PlaneType.Boing,
                        Arrive = DateTime.Now.AddDays(2),
                        PassengersAmount = 10,
                        PassengersFee = 5,
                        CrewAmount = 3,
                        CrewFee = 10,
                        Markup = 15
                    },
                    new Entry
                    {
                        FlightNum = 2,
                        PlaneType = PlaneType.Airbus,
                        Arrive = DateTime.Now.AddDays(3),
                        PassengersAmount = 20,
                        PassengersFee = 6,
                        CrewAmount = 4,
                        CrewFee = 15,
                        Markup = 20
                    },
                    new Entry
                    {
                        FlightNum = 1,
                        PlaneType = PlaneType.Oak,
                        Arrive = DateTime.Now.AddDays(4),
                        PassengersAmount = 30,
                        PassengersFee = 7,
                        CrewAmount = 5,
                        CrewFee = 20,
                        Markup = 25
                    },
                ];
            dataGridView.AutoGenerateColumns = false;

            bindingSource.DataSource = entries;
            dataGridView.DataSource = bindingSource;

            ColumnFlightNum.DataPropertyName = nameof(Entry.FlightNum);
            ColumnPlaneType.DataPropertyName = nameof(Entry.PlaneType);
            ColumnArrive.DataPropertyName = nameof(Entry.Arrive);
            ColumnPassengersAmount.DataPropertyName = nameof(Entry.PassengersAmount);
            ColumnPassengerFee.DataPropertyName = nameof(Entry.PassengersFee);
            ColumnCrewAmount.DataPropertyName = nameof(Entry.CrewAmount);
            ColumnCrewFee.DataPropertyName = nameof(Entry.CrewFee);
            ColumnMarkup.DataPropertyName = nameof(Entry.Markup);

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
                var entry = (Entry)dataGridView.Rows[e.RowIndex].DataBoundItem;
                var result = (entry.PassengersAmount * entry.PassengersFee + entry.CrewAmount * entry.CrewFee);
                e.Value = result * (entry.Markup / 100) + result; // Добавление процента надбавки
            }
        }

        private void OnAddEntry(object? sender, EventArgs e)
        {
            var entryForm = new EntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                entries.Add(entryForm.ResultEntry);
                OnUpdate();
            }
        }

        private void OnChangeEntry(object? sender, EventArgs e)
        {
            if (!CheckSelectedRows()) 
            {
                return;
            }
            var selectedEntry = entries[dataGridView.SelectedRows[0].Index];
            var entryForm = new EntryForm(selectedEntry);
            entryForm.ShowDialog();
            OnUpdate();
        }

        private void OnDeleteEntry(object? sender, EventArgs e)
        {
            if (!CheckSelectedRows())
            { 
                return; 
            }
            var selectedEntry = entries[dataGridView.SelectedRows[0].Index];
            entries.Remove(selectedEntry);
            OnUpdate();
        }

        private void CountStatistics()
        {
            var arrivingFlights = entries.Count;
            var allPassengers = entries.Sum(x => x.PassengersAmount);
            var allCrew = entries.Sum(x => x.CrewAmount);
            var allRevenue = entries.Sum(x =>
            {
                var result = (x.PassengersAmount * x.PassengersFee + x.CrewAmount * x.CrewFee);
                return result * (x.Markup / 100) + result; // Добавление процента надбавки
            });

            toolStripStatusLabelArriving.Text = $"Прибывают: {arrivingFlights}";
            toolStripStatusLabelPassengers.Text = $"Пассажиры: {allPassengers}";
            toolStripStatusLabelCrew.Text = $"Экипаж: {allCrew}";
            toolStripStatusLabelRevenue.Text = $"Выручка: {allRevenue}";
        }

        private void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            CountStatistics();
        }

        private bool CheckSelectedRows()
        {
            if (dataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну запись", "Ошибка", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
