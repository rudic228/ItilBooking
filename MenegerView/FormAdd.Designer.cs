﻿namespace MenegerView
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
            textBoxFIO = new TextBox();
            label2 = new Label();
            textBoxFloor = new TextBox();
            label3 = new Label();
            textBoxRoom = new TextBox();
            label4 = new Label();
            textBoxPrice = new TextBox();
            label5 = new Label();
            textBoxSum = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            groupBox1 = new GroupBox();
            buttonAdd = new Button();
            buttonBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 0;
            label1.Text = "ФИО:";
            // 
            // textBoxFIO
            // 
            textBoxFIO.Location = new Point(72, 12);
            textBoxFIO.Name = "textBoxFIO";
            textBoxFIO.ReadOnly = true;
            textBoxFIO.Size = new Size(203, 23);
            textBoxFIO.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 2;
            label2.Text = "Этаж:";
            // 
            // textBoxFloor
            // 
            textBoxFloor.Location = new Point(74, 54);
            textBoxFloor.Name = "textBoxFloor";
            textBoxFloor.ReadOnly = true;
            textBoxFloor.Size = new Size(47, 23);
            textBoxFloor.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(127, 52);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 4;
            label3.Text = "Комната:";
            // 
            // textBoxRoom
            // 
            textBoxRoom.Location = new Point(219, 54);
            textBoxRoom.Name = "textBoxRoom";
            textBoxRoom.ReadOnly = true;
            textBoxRoom.Size = new Size(56, 23);
            textBoxRoom.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 6;
            label4.Text = "Цена:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(72, 96);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.ReadOnly = true;
            textBoxPrice.Size = new Size(203, 23);
            textBoxPrice.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 134);
            label5.Name = "label5";
            label5.Size = new Size(73, 25);
            label5.TabIndex = 8;
            label5.Text = "Сумма:";
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(87, 134);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.ReadOnly = true;
            textBoxSum.Size = new Size(188, 23);
            textBoxSum.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(97, 160);
            label6.Name = "label6";
            label6.Size = new Size(120, 25);
            label6.TabIndex = 10;
            label6.Text = "Дата начала";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(91, 162);
            label7.Name = "label7";
            label7.Size = new Size(120, 25);
            label7.TabIndex = 11;
            label7.Text = "Дата начала";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(91, 216);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 12;
            label8.Text = "Дата конца";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(12, 190);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(279, 23);
            dateTimePickerStart.TabIndex = 13;
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(12, 244);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(279, 23);
            dateTimePickerEnd.TabIndex = 14;
            dateTimePickerEnd.ValueChanged += dateTimePickerEnd_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(11, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 258);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 273);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(279, 27);
            buttonAdd.TabIndex = 16;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(12, 306);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(279, 27);
            buttonBack.TabIndex = 17;
            buttonBack.Text = "Отмена";
            buttonBack.UseVisualStyleBackColor = true;
            // 
            // FormAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(303, 338);
            Controls.Add(buttonBack);
            Controls.Add(buttonAdd);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBoxSum);
            Controls.Add(label5);
            Controls.Add(textBoxPrice);
            Controls.Add(label4);
            Controls.Add(textBoxRoom);
            Controls.Add(label3);
            Controls.Add(textBoxFloor);
            Controls.Add(label2);
            Controls.Add(textBoxFIO);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "FormAdd";
            Text = "Заселение";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFIO;
        private Label label2;
        private TextBox textBoxFloor;
        private Label label3;
        private TextBox textBoxRoom;
        private Label label4;
        private TextBox textBoxPrice;
        private Label label5;
        private TextBox textBoxSum;
        private Label label6;
        private Label label7;
        private Label label8;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private GroupBox groupBox1;
        private Button buttonAdd;
        private Button buttonBack;
    }
}