namespace MenegerView
{
    partial class FormWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWork));
            menuStrip1 = new MenuStrip();
            работаСЗаселениемToolStripMenuItem = new ToolStripMenuItem();
            заселениеИзБронированияToolStripMenuItem = new ToolStripMenuItem();
            создатьНовоеЗаселениеToolStripMenuItem = new ToolStripMenuItem();
            архивToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { работаСЗаселениемToolStripMenuItem, архивToolStripMenuItem, оПрограммеToolStripMenuItem, выходToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(746, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // работаСЗаселениемToolStripMenuItem
            // 
            работаСЗаселениемToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заселениеИзБронированияToolStripMenuItem, создатьНовоеЗаселениеToolStripMenuItem });
            работаСЗаселениемToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            работаСЗаселениемToolStripMenuItem.Name = "работаСЗаселениемToolStripMenuItem";
            работаСЗаселениемToolStripMenuItem.Size = new Size(170, 25);
            работаСЗаселениемToolStripMenuItem.Text = "Работа с заселением";
            // 
            // заселениеИзБронированияToolStripMenuItem
            // 
            заселениеИзБронированияToolStripMenuItem.Name = "заселениеИзБронированияToolStripMenuItem";
            заселениеИзБронированияToolStripMenuItem.Size = new Size(283, 26);
            заселениеИзБронированияToolStripMenuItem.Text = "Заселение из бронирования";
            // 
            // создатьНовоеЗаселениеToolStripMenuItem
            // 
            создатьНовоеЗаселениеToolStripMenuItem.Name = "создатьНовоеЗаселениеToolStripMenuItem";
            создатьНовоеЗаселениеToolStripMenuItem.Size = new Size(283, 26);
            создатьНовоеЗаселениеToolStripMenuItem.Text = "Создать новое заселение";
            создатьНовоеЗаселениеToolStripMenuItem.Click += создатьНовоеЗаселениеToolStripMenuItem_Click;
            // 
            // архивToolStripMenuItem
            // 
            архивToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            архивToolStripMenuItem.Name = "архивToolStripMenuItem";
            архивToolStripMenuItem.Size = new Size(65, 25);
            архивToolStripMenuItem.Text = "Архив";
            архивToolStripMenuItem.Click += архивToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(118, 25);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(67, 25);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(0, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(746, 443);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // FormWork
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 469);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormWork";
            Text = "Основная форма";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem работаСЗаселениемToolStripMenuItem;
        private ToolStripMenuItem заселениеИзБронированияToolStripMenuItem;
        private ToolStripMenuItem создатьНовоеЗаселениеToolStripMenuItem;
        private ToolStripMenuItem архивToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}