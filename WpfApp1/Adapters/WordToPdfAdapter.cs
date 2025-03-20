using WpfApp1.Models;
using System;

namespace WpfApp1.Adapters
{
    public class WordToPdfAdapter : IDocumentAdapter
    {
        private readonly WordDocument _wordDocument;
        private readonly PdfHandler _pdfHandler;

        public WordToPdfAdapter(WordDocument wordDocument, PdfHandler pdfHandler)
        {
            _wordDocument = wordDocument;
            _pdfHandler = pdfHandler;
        }

        public void Convert(string sourceFilePath, string targetFilePath)
        {
            // Чтение текста из Word
            string content = _wordDocument.ReadWord(sourceFilePath);

            // Проверка, что текст не пустой
            if (string.IsNullOrEmpty(content))
            {
                Console.WriteLine("Текст не был извлечен из Word.");
                return;
            }

            // Логирование текста для отладки
            Console.WriteLine($"Извлеченный текст: {content}");

            // Запись текста в PDF
            _pdfHandler.WritePdf(targetFilePath, content);
        }
    }
}