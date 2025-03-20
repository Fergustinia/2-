using Xceed.Words.NET;
using System;

namespace WpfApp1.Models
{
    public class WordDocument
    {
        public string ReadWord(string filePath)
        {
            try
            {
                // Логика чтения текста из Word
                using (DocX document = DocX.Load(filePath))
                {
                    string text = document.Text;
                    Console.WriteLine($"Извлеченный текст из Word: {text}"); // Логирование текста
                    return text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении Word: {ex.Message}");
                return string.Empty;
            }
        }

        public void WriteWord(string filePath, string content)
        {
            try
            {
                // Логика записи текста в Word
                using (DocX document = DocX.Create(filePath))
                {
                    document.InsertParagraph(content);
                    document.Save();
                }
                Console.WriteLine($"Запись Word-документа: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи Word: {ex.Message}");
            }
        }
    }
}