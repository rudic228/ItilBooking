namespace MenegerView
{
    partial class FormAddUser
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
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxName = new TextBox();
            textBoxSurname = new TextBox();
            textBoxLastName = new TextBox();
            textBoxPhone = new TextBox();
            textBoxMail = new TextBox();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 92);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "Телефон";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 121);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 5;
            label6.Text = "Почта";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(49, 6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(222, 23);
            textBoxName.TabIndex = 7;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(76, 32);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(195, 23);
            textBoxSurname.TabIndex = 8;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(76, 60);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(195, 23);
            textBoxLastName.TabIndex = 9;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(73, 89);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(198, 23);
            textBoxPhone.TabIndex = 11;
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(59, 118);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(212, 23);
            textBoxMail.TabIndex = 12;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 147);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(253, 23);
            buttonAdd.TabIndex = 13;
            buttonAdd.Text = "ОК";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 177);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxMail);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAddUser";
            Text = "Создание человека";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private TextBox textBoxName;
        private TextBox textBoxSurname;
        private TextBox textBoxLastName;
        private TextBox textBoxPhone;
        private TextBox textBoxMail;
        private Button buttonAdd;
    }
}