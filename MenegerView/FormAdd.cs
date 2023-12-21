﻿using Dal;
using Dal.Entities;
//using DocumentFormat.OpenXml.Wordprocessing;
using MenegerView.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Xml;
using Aspose.Words;


namespace MenegerView
{
    public partial class FormAdd : Form
    {
        Context context = new Context();
        Guid nameId;
        Guid roomId;
        public FormAdd(Guid NameId, Guid RoomId)
        {
            InitializeComponent();
            nameId = NameId;
            roomId = RoomId;

            var user = context.Users
                .Where(u => u.Id == NameId)
                .FirstOrDefault();

            var room = context.Rooms
                .Where(u => u.Id == RoomId)
                .FirstOrDefault();
            textBoxFIO.Text = user.FullName;
            textBoxFloor.Text = room.Level.ToString();
            textBoxPrice.Text = room.Price.ToString();
            textBoxRoom.Text = room.Number.ToString();
        }

        private void ChangeDate()
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                MessageBox.Show("Дата начала не может быть больше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerStart.Value == dateTimePickerEnd.Value)
            {
                MessageBox.Show("Дата начала не может быть равна конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int start = dateTimePickerStart.Value.Day;
            int end = dateTimePickerEnd.Value.Day;
            textBoxSum.Text = (Convert.ToDecimal(textBoxPrice.Text) * (end - start)).ToString();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            ChangeDate();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            ChangeDate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                MessageBox.Show("Дата начала не может быть больше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerStart.Value == dateTimePickerEnd.Value)
            {
                MessageBox.Show("Дата начала не может быть равна конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Checkin checkin = new Checkin
            {
                Id = new Guid(),
                RoomId = roomId,
                BeginCheckinDate = dateTimePickerStart.Value,
                EndCheckinDate = dateTimePickerEnd.Value,
                Price = Convert.ToDecimal(textBoxSum.Text),
                UserId = nameId
            };
            context.Checkins.Add(checkin);
            context.SaveChanges();

            string templateFilePath = "D:\\курсоваяРабота\\шаблон.doc";
            string outputFolderPath = "D:\\курсоваяРабота\\квитанции";
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("ФИО", textBoxFIO.Text);
            double number = double.Parse(textBoxSum.Text);
            int integerPart = (int)number;
            int fractionalPart = (int)((number - integerPart)*100);
            data.Add("Рубли", integerPart.ToString());
            data.Add("Копейки", fractionalPart.ToString());
            data.Add("Год", DateTime.Today.Year.ToString());
            data.Add("Месяц", DateTime.Today.Month.ToString());
            data.Add("День", DateTime.Today.Day.ToString());

            FillAndSaveTemplate(templateFilePath, outputFolderPath,  data, textBoxFIO.Text);

            MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FormWork formwork = new FormWork();
            formwork.ShowDialog();

        }

        public void FillAndSaveTemplate(string templateFilePath, string outputFolderPath, Dictionary<string, string> data, string name)
        {
            // Загружаем документ Word из файла шаблона
            Document doc = new Document(templateFilePath);

            // Заполняем места, где стоят закладки, значениями из словаря
            foreach (KeyValuePair<string, string> entry in data)
            {
                Bookmark bookmark = doc.Range.Bookmarks[entry.Key];
                if (bookmark != null)
                {
                    bookmark.Text = entry.Value;
                }
            }

            string outputFileName = $"{DateTime.Now:yyyy-MM-dd} {name} .docx";

            // Сохраняем заполненный файл в указанной папке с уникальным именем
            doc.Save(System.IO.Path.Combine(outputFolderPath, outputFileName));
        }


    }
}
