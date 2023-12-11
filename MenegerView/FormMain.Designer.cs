namespace MenegerView
{
    partial class FormMain
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
            Id = new DataGridViewTextBoxColumn();
            FIO = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            buttonBook = new Button();
            buttonAdd = new Button();
            buttonDel = new Button();
            buttonRef = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, FIO, Room, StartDate, EndDate });
            dataGridView1.Location = new Point(13, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(684, 480);
            dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // FIO
            // 
            FIO.HeaderText = "ФИО";
            FIO.Name = "FIO";
            FIO.Width = 300;
            // 
            // Room
            // 
            Room.HeaderText = "Комната";
            Room.Name = "Room";
            // 
            // StartDate
            // 
            StartDate.HeaderText = "Дата Начала";
            StartDate.Name = "StartDate";
            StartDate.Width = 120;
            // 
            // EndDate
            // 
            EndDate.HeaderText = "Дата Конца";
            EndDate.Name = "EndDate";
            EndDate.Width = 120;
            // 
            // buttonBook
            // 
            buttonBook.Location = new Point(1, 1);
            buttonBook.Name = "buttonBook";
            buttonBook.Size = new Size(144, 45);
            buttonBook.TabIndex = 1;
            buttonBook.Text = "Добавить из бронирования";
            buttonBook.UseVisualStyleBackColor = true;
            buttonBook.Click += buttonBook_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(1, 52);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(144, 45);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Добавить без бронирования";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDel
            // 
            buttonDel.Location = new Point(1, 103);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(144, 26);
            buttonDel.TabIndex = 3;
            buttonDel.Text = "Удалить";
            buttonDel.UseVisualStyleBackColor = true;
            buttonDel.Click += buttonDel_Click;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(1, 135);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(144, 24);
            buttonRef.TabIndex = 4;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += buttonRef_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonRef);
            groupBox1.Controls.Add(buttonDel);
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Controls.Add(buttonBook);
            groupBox1.Location = new Point(703, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(145, 160);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 504);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn FIO;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
        private Button buttonBook;
        private Button buttonAdd;
        private Button buttonDel;
        private Button buttonRef;
        private GroupBox groupBox1;
    }
}