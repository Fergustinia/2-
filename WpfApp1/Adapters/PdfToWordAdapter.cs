using WpfApp1.Models;

namespace WpfApp1.Adapters
{
    public class PdfToWordAdapter : IDocumentAdapter
    {
        private readonly PdfHandler _pdfHandler;
        private readonly WordDocument _wordDocument;

        public PdfToWordAdapter(PdfHandler pdfHandler, WordDocument wordDocument)
        {
            _pdfHandler = pdfHandler;
            _wordDocument = wordDocument;
        }

        public void Convert(string sourceFilePath, string targetFilePath)
        {
            // Чтение текста из PDF
            string content = _pdfHandler.ReadPdf(sourceFilePath);

            // Запись текста в Word
            _wordDocument.WriteWord(targetFilePath, content);
        }
    }
}