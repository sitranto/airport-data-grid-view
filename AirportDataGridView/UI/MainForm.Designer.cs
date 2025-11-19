namespace AirportDataGridView.App.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            addToolStripMenuItem = new ToolStripMenuItem();
            changeToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabelArriving = new ToolStripStatusLabel();
            toolStripStatusLabelPassengers = new ToolStripStatusLabel();
            toolStripStatusLabelCrew = new ToolStripStatusLabel();
            toolStripStatusLabelRevenue = new ToolStripStatusLabel();
            dataGridView = new DataGridView();
            ColumnFlightNum = new DataGridViewTextBoxColumn();
            ColumnPlaneType = new DataGridViewTextBoxColumn();
            ColumnArrive = new DataGridViewTextBoxColumn();
            ColumnPassengersAmount = new DataGridViewTextBoxColumn();
            ColumnPassengerFee = new DataGridViewTextBoxColumn();
            ColumnCrewAmount = new DataGridViewTextBoxColumn();
            ColumnCrewFee = new DataGridViewTextBoxColumn();
            ColumnMarkup = new DataGridViewTextBoxColumn();
            ColumnRevenue = new DataGridViewTextBoxColumn();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, changeToolStripMenuItem, deleteToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(941, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(71, 20);
            addToolStripMenuItem.Text = "Добавить";
            addToolStripMenuItem.Click += OnAddEntry;
            // 
            // changeToolStripMenuItem
            // 
            changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            changeToolStripMenuItem.Size = new Size(73, 20);
            changeToolStripMenuItem.Text = "Изменить";
            changeToolStripMenuItem.Click += OnChangeEntry;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(63, 20);
            deleteToolStripMenuItem.Text = "Удалить";
            deleteToolStripMenuItem.Click += OnDeleteEntry;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelArriving, toolStripStatusLabelPassengers, toolStripStatusLabelCrew, toolStripStatusLabelRevenue });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(941, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelArriving
            // 
            toolStripStatusLabelArriving.Name = "toolStripStatusLabelArriving";
            toolStripStatusLabelArriving.Size = new Size(76, 17);
            toolStripStatusLabelArriving.Text = "Прибывают:";
            // 
            // toolStripStatusLabelPassengers
            // 
            toolStripStatusLabelPassengers.Name = "toolStripStatusLabelPassengers";
            toolStripStatusLabelPassengers.Size = new Size(75, 17);
            toolStripStatusLabelPassengers.Text = "Пассажиры:";
            // 
            // toolStripStatusLabelCrew
            // 
            toolStripStatusLabelCrew.Name = "toolStripStatusLabelCrew";
            toolStripStatusLabelCrew.Size = new Size(52, 17);
            toolStripStatusLabelCrew.Text = "Экипаж:";
            // 
            // toolStripStatusLabelRevenue
            // 
            toolStripStatusLabelRevenue.Name = "toolStripStatusLabelRevenue";
            toolStripStatusLabelRevenue.Size = new Size(58, 17);
            toolStripStatusLabelRevenue.Text = "Выручка:";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnFlightNum, ColumnPlaneType, ColumnArrive, ColumnPassengersAmount, ColumnPassengerFee, ColumnCrewAmount, ColumnCrewFee, ColumnMarkup, ColumnRevenue });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 24);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(941, 404);
            dataGridView.TabIndex = 2;
            dataGridView.CellFormatting += OnCellFormatting;
            // 
            // ColumnFlightNum
            // 
            ColumnFlightNum.HeaderText = "Номер рейса";
            ColumnFlightNum.Name = "ColumnFlightNum";
            ColumnFlightNum.ReadOnly = true;
            // 
            // ColumnPlaneType
            // 
            ColumnPlaneType.HeaderText = "Тип самолета";
            ColumnPlaneType.Name = "ColumnPlaneType";
            ColumnPlaneType.ReadOnly = true;
            // 
            // ColumnArrive
            // 
            ColumnArrive.HeaderText = "Время прибытия";
            ColumnArrive.Name = "ColumnArrive";
            ColumnArrive.ReadOnly = true;
            // 
            // ColumnPassengersAmount
            // 
            ColumnPassengersAmount.HeaderText = "Количество пассажиров";
            ColumnPassengersAmount.Name = "ColumnPassengersAmount";
            ColumnPassengersAmount.ReadOnly = true;
            // 
            // ColumnPassengerFee
            // 
            ColumnPassengerFee.HeaderText = "Сбор на пассажира";
            ColumnPassengerFee.Name = "ColumnPassengerFee";
            ColumnPassengerFee.ReadOnly = true;
            // 
            // ColumnCrewAmount
            // 
            ColumnCrewAmount.HeaderText = "Количество экипажа";
            ColumnCrewAmount.Name = "ColumnCrewAmount";
            ColumnCrewAmount.ReadOnly = true;
            // 
            // ColumnCrewFee
            // 
            ColumnCrewFee.HeaderText = "Сбор на экипаж";
            ColumnCrewFee.Name = "ColumnCrewFee";
            ColumnCrewFee.ReadOnly = true;
            // 
            // ColumnMarkup
            // 
            ColumnMarkup.HeaderText = "Процент надбавки за обслуживание";
            ColumnMarkup.Name = "ColumnMarkup";
            ColumnMarkup.ReadOnly = true;
            // 
            // ColumnRevenue
            // 
            ColumnRevenue.HeaderText = "Выручка";
            ColumnRevenue.Name = "ColumnRevenue";
            ColumnRevenue.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 450);
            Controls.Add(dataGridView);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Аэропорт";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private DataGridView dataGridView;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem changeToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabelArriving;
        private ToolStripStatusLabel toolStripStatusLabelPassengers;
        private ToolStripStatusLabel toolStripStatusLabelCrew;
        private ToolStripStatusLabel toolStripStatusLabelRevenue;
        private DataGridViewTextBoxColumn ColumnFlightNum;
        private DataGridViewTextBoxColumn ColumnPlaneType;
        private DataGridViewTextBoxColumn ColumnArrive;
        private DataGridViewTextBoxColumn ColumnPassengersAmount;
        private DataGridViewTextBoxColumn ColumnPassengerFee;
        private DataGridViewTextBoxColumn ColumnCrewAmount;
        private DataGridViewTextBoxColumn ColumnCrewFee;
        private DataGridViewTextBoxColumn ColumnMarkup;
        private DataGridViewTextBoxColumn ColumnRevenue;
    }
}
