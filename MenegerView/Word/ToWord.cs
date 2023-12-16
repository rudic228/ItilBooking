using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;

namespace MenegerView.Word
{
   public class ToWord
    {
        public static void ExportData(string name, string price, string starttime, string endtime)
        {
            CommonSaveFileDialog saveFileDialog = new CommonSaveFileDialog();
            saveFileDialog.Title = "Выберите путь сохранения";
            saveFileDialog.Filters.Add(new CommonFileDialogFilter("Документы Word", "*.docx"));
            if (saveFileDialog.ShowDialog() != CommonFileDialogResult.Ok) return;

            string outputPath = saveFileDialog.FileName;
            using (WordprocessingDocument doc = WordprocessingDocument.Create(outputPath, WordprocessingDocumentType.Document))
            {
                // Добавление основного содержимого документа
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Заполнение данными
                Paragraph paragraph = body.AppendChild(new Paragraph());
                Run run = paragraph.AppendChild(new Run());
                run.AppendChild(new Text($"Покупатель: {name}"));

                paragraph = body.AppendChild(new Paragraph());
                run = paragraph.AppendChild(new Run());
                run.AppendChild(new Text($"Стоимость: {price}"));

                paragraph = body.AppendChild(new Paragraph());
                run = paragraph.AppendChild(new Run());
                run.AppendChild(new Text($"Дата заселения: {starttime}"));

                paragraph = body.AppendChild(new Paragraph());
                run = paragraph.AppendChild(new Run());
                run.AppendChild(new Text($"Дата выезда: {endtime}"));
            }
        }
    }
}
