using AirportDataGridView.Infrastructure;
using AirportDataGridView.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace AirportDataGridView.App.UI
{
    /// <summary>
    /// Класс формы добавления и изменения данных
    /// </summary>
    public partial class EntryForm : Form
    {
        private readonly Entry entry;

        /// <summary>
        /// Свойство записи
        /// </summary>
        public Entry ResultEntry => entry;

        /// <summary>
        /// Конструктор для класса <see cref="EntryForm"/>
        /// </summary>
        /// <param name="sourceEntry">Исходная запись для операции изменения</param>
        public EntryForm(Entry? sourceEntry = null)
        {
            InitializeComponent();

            comboBoxPlaneType.DataSource = Enum.GetValues(typeof (PlaneType));

            if (sourceEntry == null)
            {
                entry = new Entry();
                button.Text = "Добавить";
            }
            else
            {
                entry = sourceEntry;
                button.Text = "Сохранить";
            }

            textBoxFlightNum.AddBinding(x => x.Text, entry, x => x.FlightNum, errorProvider);
            comboBoxPlaneType.AddBinding(x => x.SelectedItem!, entry, x => x.PlaneType, errorProvider);
            textBoxArrive.AddBinding(x => x.Text, entry, x => x.Arrive, errorProvider);
            textBoxPassengersAmount.AddBinding(x => x.Text, entry, x => x.PassengersAmount, errorProvider);
            textBoxPassengersFee.AddBinding(x => x.Text, entry, x => x.PassengersFee, errorProvider);
            textBoxCrewAmount.AddBinding(x => x.Text, entry, x => x.CrewAmount, errorProvider);
            textBoxCrewFee.AddBinding(x => x.Text, entry, x => x.CrewFee, errorProvider);
            textBoxMarkup.AddBinding(x => x.Text, entry, x => x.Markup, errorProvider);
        }

        private void OnButtonClick(object? sender, EventArgs e)
        {
            errorProvider.Clear();

            var context = new ValidationContext(entry);
            var resulsts = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entry, context, resulsts, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                foreach (var result in resulsts)
                {
                    foreach(var memberName in result.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(Entry.FlightNum) => textBoxFlightNum,
                            nameof(Entry.PlaneType) => comboBoxPlaneType,
                            nameof(Entry.Arrive) => textBoxArrive,
                            nameof(Entry.PassengersAmount) => textBoxPassengersAmount,
                            nameof(Entry.PassengersFee) => textBoxPassengersFee,
                            nameof(Entry.CrewAmount) => textBoxCrewAmount,
                            nameof(Entry.CrewFee) => textBoxCrewFee,
                            nameof(Entry.Markup) => textBoxMarkup,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, result.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
