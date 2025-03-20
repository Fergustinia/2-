using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Layout;
using iText.Layout.Element;
using System;

namespace WpfApp1.Models
{
    public class PdfHandler
    {
        public string ReadPdf(string filePath)
        {
            try
            {
                // Логика чтения текста из PDF
                using (PdfReader reader = new PdfReader(filePath))
                {
                    using (iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader))
                    {
                        string text = string.Empty;
                        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), strategy);

                            // Добавляем пробелы между словами
                            pageText = pageText.Replace("\n", " "); // Заменяем переносы строк на пробелы
                            text += pageText + " "; // Добавляем пробел между страницами
                        }
                        return text.Trim(); // Убираем лишние пробелы в начале и конце
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении PDF: {ex.Message}");
                return string.Empty;
            }
        }

        public void WritePdf(string filePath, string content)
        {
            try
            {
                // Логика записи текста в PDF
                using (PdfWriter writer = new PdfWriter(filePath))
                {
                    using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                    {
                        Document document = new Document(pdf);
                        document.Add(new Paragraph(content)); // Теперь Paragraph будет распознан
                        document.Close();
                    }
                }
                Console.WriteLine($"Запись PDF-документа: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи PDF: {ex.Message}");
            }
        }
    }
}