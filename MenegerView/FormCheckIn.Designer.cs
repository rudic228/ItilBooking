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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            textBoxRoom = new TextBox();
            buttonFiltr = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            textBoxName.Location = new Point(6, 15);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(148, 23);
            textBoxName.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxName);
            groupBox1.Location = new Point(640, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(157, 44);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "ФИО";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxRoom);
            groupBox2.Location = new Point(640, 56);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(157, 45);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Комната";
            // 
            // textBoxRoom
            // 
            textBoxRoom.Location = new Point(6, 16);
            textBoxRoom.Name = "textBoxRoom";
            textBoxRoom.Size = new Size(142, 23);
            textBoxRoom.TabIndex = 0;
            // 
            // buttonFiltr
            // 
            buttonFiltr.Location = new Point(640, 107);
            buttonFiltr.Name = "buttonFiltr";
            buttonFiltr.Size = new Size(154, 23);
            buttonFiltr.TabIndex = 5;
            buttonFiltr.Text = "Фильтрация";
            buttonFiltr.UseVisualStyleBackColor = true;
            buttonFiltr.Click += buttonFiltr_Click;
            // 
            // FormCheckIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFiltr);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "FormCheckIn";
            Text = "Заселенные";
            Load += FormCheckIn_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBoxName;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBoxRoom;
        private Button buttonFiltr;
    }
}