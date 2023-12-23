namespace MenegerView
{
    partial class FormUsers
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
            label1 = new Label();
            textBox1 = new TextBox();
            buttonSearch = new Button();
            buttonNext = new Button();
            buttonBack = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(577, 439);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(597, 14);
            label1.Name = "label1";
            label1.Size = new Size(251, 25);
            label1.TabIndex = 1;
            label1.Text = "Поиск по номеру телефона";
            // 
            // textBox1
            // 
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Location = new Point(597, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += buttonSearch_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSearch.Location = new Point(597, 71);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(245, 49);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonNext
            // 
            buttonNext.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNext.Location = new Point(597, 359);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(251, 50);
            buttonNext.TabIndex = 4;
            buttonNext.Text = "Далее";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBack.Location = new Point(597, 415);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(251, 38);
            buttonBack.TabIndex = 5;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonClear
            // 
            buttonClear.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear.Location = new Point(597, 126);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(245, 35);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Очистить поиск";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // FormUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 465);
            Controls.Add(buttonClear);
            Controls.Add(buttonBack);
            Controls.Add(buttonNext);
            Controls.Add(buttonSearch);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FormUsers";
            Text = "Пользователи";
            Load += FormUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Button buttonSearch;
        private Button buttonNext;
        private Button buttonBack;
        private Button buttonClear;
    }
}