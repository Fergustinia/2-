using WpfApp1.Adapters;
using WpfApp1.Models;
using System.Windows;
using Microsoft.Win32; // Для использования OpenFileDialog и SaveFileDialog

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertPdfToWord_Click(object sender, RoutedEventArgs e)
        {
            // Диалог для выбора исходного PDF-файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFilePath = openFileDialog.FileName;

                // Диалог для выбора места сохранения Word-файла
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
                saveFileDialog.FileName = "output.docx"; // Имя по умолчанию
                if (saveFileDialog.ShowDialog() == true)
                {
                    string targetFilePath = saveFileDialog.FileName;

                    // Конвертация PDF в Word
                    PdfHandler pdfDocument = new PdfHandler();
                    WordDocument wordDocument = new WordDocument();
                    IDocumentAdapter adapter = new PdfToWordAdapter(pdfDocument, wordDocument);

                    adapter.Convert(sourceFilePath, targetFilePath);
                    StatusTextBlock.Text = "Статус: PDF успешно конвертирован в Word!";
                }
            }
        }

        private void ConvertWordToPdf_Click(object sender, RoutedEventArgs e)
        {
            // Диалог для выбора исходного Word-файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFilePath = openFileDialog.FileName;

                // Диалог для выбора места сохранения PDF-файла
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FileName = "output.pdf"; // Имя по умолчанию
                if (saveFileDialog.ShowDialog() == true)
                {
                    string targetFilePath = saveFileDialog.FileName;

                    // Конвертация Word в PDF
                    WordDocument wordDocument = new WordDocument();
                    PdfHandler pdfDocument = new PdfHandler();
                    IDocumentAdapter adapter = new WordToPdfAdapter(wordDocument, pdfDocument);

                    adapter.Convert(sourceFilePath, targetFilePath);
                    StatusTextBlock.Text = "Статус: Word успешно конвертирован в PDF!";
                }
            }
        }
    }
}