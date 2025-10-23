using AirportDataGridView.Forms;

namespace AirportDataGridView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnAddEntry(object? sender, EventArgs e)
        {
            var entryForm = new EntryForm();
            entryForm.ShowDialog();
        }

        private void OnChangeEntry(object? sender, EventArgs e)
        {
            var entryForm = new EntryForm();
            entryForm.ShowDialog();
        }
    }
}
