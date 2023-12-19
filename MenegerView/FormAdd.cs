using Dal;
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
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;


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

            // Путь к шаблону документа
            string templatePath = @"..\\курсоваяРабота\\шаблон.doc";

            // Путь к сохраняемому документу
            string savePath = @"..\\";

            // Создание объекта приложения Word
            Application wordApp = new Application();

            // Открытие шаблона документа
            Document doc = wordApp.Documents.Open(templatePath);

            // Замена данных в закладке
            int rubls = (int)Convert.ToDouble(textBoxSum.Text);
            double kops = Convert.ToDouble(textBoxSum.Text) - rubls;
            kops = Math.Round(kops, 2);
            ReplaceBookmark(doc, "ФИО", textBoxFIO.Text);
            ReplaceBookmark(doc, "Рубли", rubls.ToString());
            ReplaceBookmark(doc, "Копейки", kops.ToString());
            ReplaceBookmark(doc, "День", DateTime.Today.Day.ToString());
            ReplaceBookmark(doc, "Месяц", DateTime.Today.Month.ToString());
            ReplaceBookmark(doc, "Год", DateTime.Today.Year.ToString());

            // Сохранение документа
            doc.SaveAs2(savePath);

            // Закрытие документа и приложения Word
            doc.Close();
            wordApp.Quit();

            MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        static void ReplaceBookmark(Document doc, string bookmarkName, string replacementText)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {
                // Получение закладки
                Bookmark bookmark = doc.Bookmarks[bookmarkName];

                // Удаление содержимого закладки
                bookmark.Range.Delete();

                // Вставка нового текста в закладку
                bookmark.Range.InsertAfter(replacementText);

                // Добавление закладки вновь вставленному тексту
                doc.Bookmarks.Add(bookmarkName, bookmark.Range);
            }
        }


    }
}
