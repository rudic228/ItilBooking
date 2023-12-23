namespace MenegerView
{
    partial class FormCheckIn
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
            textBoxName = new TextBox();
            label1 = new Label();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(622, 426);
            dataGridView1.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(640, 40);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(149, 23);
            textBoxName.TabIndex = 1;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(649, 12);
            label1.Name = "label1";
            label1.Size = new Size(140, 25);
            label1.TabIndex = 2;
            label1.Text = "Поиск по ФИО";
            // 
            // buttonClear
            // 
            buttonClear.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear.Location = new Point(640, 69);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(148, 32);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Очистить поиск";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // FormCheckIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonClear);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(dataGridView1);
            Name = "FormCheckIn";
            Text = "Заселенные";
            Load += FormCheckIn_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBoxName;
        private Label label1;
        private Button buttonClear;
    }
}