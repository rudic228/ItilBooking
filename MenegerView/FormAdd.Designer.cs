namespace MenegerView
{
    partial class FormAdd
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            textBoxSum = new TextBox();
            comboBoxFIO = new ComboBox();
            buttonOK = new Button();
            buttonCheck = new Button();
            comboBoxNumber = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "ФИО";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Сумма";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 69);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 3;
            label4.Text = "Номер";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 101);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 4;
            label5.Text = "Дата Начала";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 127);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 5;
            label6.Text = "Дата Конца";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(94, 95);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(252, 23);
            dateTimePickerStart.TabIndex = 6;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(94, 124);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(252, 23);
            dateTimePickerEnd.TabIndex = 7;
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(63, 41);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.Size = new Size(283, 23);
            textBoxSum.TabIndex = 9;
            // 
            // comboBoxFIO
            // 
            comboBoxFIO.FormattingEnabled = true;
            comboBoxFIO.Location = new Point(52, 12);
            comboBoxFIO.Name = "comboBoxFIO";
            comboBoxFIO.Size = new Size(294, 23);
            comboBoxFIO.TabIndex = 11;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(13, 163);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 12;
            buttonOK.Text = "ОК";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCheck
            // 
            buttonCheck.Location = new Point(271, 163);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(75, 23);
            buttonCheck.TabIndex = 13;
            buttonCheck.Text = "Квитанция";
            buttonCheck.UseVisualStyleBackColor = true;
            buttonCheck.Click += buttonCheck_Click;
            // 
            // comboBoxNumber
            // 
            comboBoxNumber.FormattingEnabled = true;
            comboBoxNumber.Location = new Point(63, 69);
            comboBoxNumber.Name = "comboBoxNumber";
            comboBoxNumber.Size = new Size(283, 23);
            comboBoxNumber.TabIndex = 14;
            comboBoxNumber.SelectedIndexChanged += comboBoxNumber_SelectedIndexChanged;
            // 
            // FormAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(358, 195);
            Controls.Add(comboBoxNumber);
            Controls.Add(buttonCheck);
            Controls.Add(buttonOK);
            Controls.Add(comboBoxFIO);
            Controls.Add(textBoxSum);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FormAdd";
            Text = "FormAdd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private TextBox textBoxSum;
        private Button buttonOK;
        private Button buttonCheck;
        private ComboBox comboBoxNumber;
        public ComboBox comboBoxFIO;
    }
}