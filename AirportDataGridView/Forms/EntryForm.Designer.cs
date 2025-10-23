namespace AirportDataGridView.Forms
{
    partial class EntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxFlightNum = new TextBox();
            comboBoxPlaneType = new ComboBox();
            textBoxArrive = new TextBox();
            textBoxPassengersAmount = new TextBox();
            textBoxPassengersFee = new TextBox();
            textBoxCrewAmount = new TextBox();
            textBoxCrewFee = new TextBox();
            textBoxMarkup = new TextBox();
            button = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // textBoxFlightNum
            // 
            textBoxFlightNum.Location = new Point(145, 112);
            textBoxFlightNum.Name = "textBoxFlightNum";
            textBoxFlightNum.Size = new Size(121, 23);
            textBoxFlightNum.TabIndex = 0;
            // 
            // comboBoxPlaneType
            // 
            comboBoxPlaneType.FormattingEnabled = true;
            comboBoxPlaneType.Location = new Point(145, 155);
            comboBoxPlaneType.Name = "comboBoxPlaneType";
            comboBoxPlaneType.Size = new Size(121, 23);
            comboBoxPlaneType.TabIndex = 1;
            // 
            // textBoxArrive
            // 
            textBoxArrive.Location = new Point(145, 198);
            textBoxArrive.Name = "textBoxArrive";
            textBoxArrive.Size = new Size(121, 23);
            textBoxArrive.TabIndex = 2;
            // 
            // textBoxPassengersAmount
            // 
            textBoxPassengersAmount.Location = new Point(145, 241);
            textBoxPassengersAmount.Name = "textBoxPassengersAmount";
            textBoxPassengersAmount.Size = new Size(121, 23);
            textBoxPassengersAmount.TabIndex = 3;
            // 
            // textBoxPassengersFee
            // 
            textBoxPassengersFee.Location = new Point(333, 112);
            textBoxPassengersFee.Name = "textBoxPassengersFee";
            textBoxPassengersFee.Size = new Size(121, 23);
            textBoxPassengersFee.TabIndex = 4;
            // 
            // textBoxCrewAmount
            // 
            textBoxCrewAmount.Location = new Point(333, 155);
            textBoxCrewAmount.Name = "textBoxCrewAmount";
            textBoxCrewAmount.Size = new Size(121, 23);
            textBoxCrewAmount.TabIndex = 5;
            // 
            // textBoxCrewFee
            // 
            textBoxCrewFee.Location = new Point(333, 198);
            textBoxCrewFee.Name = "textBoxCrewFee";
            textBoxCrewFee.Size = new Size(121, 23);
            textBoxCrewFee.TabIndex = 6;
            // 
            // textBoxMarkup
            // 
            textBoxMarkup.Location = new Point(333, 241);
            textBoxMarkup.Name = "textBoxMarkup";
            textBoxMarkup.Size = new Size(121, 23);
            textBoxMarkup.TabIndex = 7;
            // 
            // button
            // 
            button.Location = new Point(262, 339);
            button.Name = "button";
            button.Size = new Size(75, 23);
            button.TabIndex = 8;
            button.Text = "Добавить";
            button.UseVisualStyleBackColor = true;
            button.Click += OnButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 94);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 9;
            label1.Text = "Номер рейса";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 138);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 10;
            label2.Text = "Самолет";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(145, 181);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 11;
            label3.Text = "Время прибытия";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(145, 224);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 12;
            label4.Text = "Число пассажиров";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(333, 94);
            label5.Name = "label5";
            label5.Size = new Size(136, 15);
            label5.TabIndex = 13;
            label5.Text = "Надбавка за пассажира";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(333, 138);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 14;
            label6.Text = "Число экипажа";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(333, 180);
            label7.Name = "label7";
            label7.Size = new Size(117, 15);
            label7.TabIndex = 15;
            label7.Text = "Надбавка за экипаж";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(333, 224);
            label8.Name = "label8";
            label8.Size = new Size(207, 15);
            label8.TabIndex = 16;
            label8.Text = "Процент надбавки за обслуживание";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // EntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 374);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button);
            Controls.Add(textBoxMarkup);
            Controls.Add(textBoxCrewFee);
            Controls.Add(textBoxCrewAmount);
            Controls.Add(textBoxPassengersFee);
            Controls.Add(textBoxPassengersAmount);
            Controls.Add(textBoxArrive);
            Controls.Add(comboBoxPlaneType);
            Controls.Add(textBoxFlightNum);
            Name = "EntryForm";
            Text = "Добавить";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFlightNum;
        private ComboBox comboBoxPlaneType;
        private TextBox textBoxArrive;
        private TextBox textBoxPassengersAmount;
        private TextBox textBoxPassengersFee;
        private TextBox textBoxCrewAmount;
        private TextBox textBoxCrewFee;
        private TextBox textBoxMarkup;
        private Button button;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ErrorProvider errorProvider;
    }
}