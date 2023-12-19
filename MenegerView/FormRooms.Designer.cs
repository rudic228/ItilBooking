namespace MenegerView
{
    partial class FormRooms
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
            dataGridView1 = new DataGridView();
            comboBoxFloor = new ComboBox();
            buttonNext = new Button();
            buttonBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(510, 417);
            dataGridView1.TabIndex = 0;
            // 
            // comboBoxFloor
            // 
            comboBoxFloor.FormattingEnabled = true;
            comboBoxFloor.Location = new Point(527, 12);
            comboBoxFloor.Name = "comboBoxFloor";
            comboBoxFloor.Size = new Size(121, 23);
            comboBoxFloor.TabIndex = 1;
            comboBoxFloor.Text = "Этаж";
            comboBoxFloor.SelectedIndexChanged += comboBoxFloor_SelectedIndexChanged;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(527, 326);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(127, 43);
            buttonNext.TabIndex = 2;
            buttonNext.Text = "Далее";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(527, 375);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(127, 43);
            buttonBack.TabIndex = 3;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // FormRooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 441);
            Controls.Add(buttonBack);
            Controls.Add(buttonNext);
            Controls.Add(comboBoxFloor);
            Controls.Add(dataGridView1);
            Name = "FormRooms";
            Text = "Выбор комнаты";
            Load += FormRooms_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBoxFloor;
        private Button buttonNext;
        private Button buttonBack;
    }
}