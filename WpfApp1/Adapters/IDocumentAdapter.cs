namespace WpfApp1.Adapters
{
    public interface IDocumentAdapter
    {
        void Convert(string sourceFilePath, string targetFilePath);
    }
}