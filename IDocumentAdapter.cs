namespace YourProject.Adapters
{
    public interface IDocumentAdapter
    {
        void Convert(string sourceFilePath, string targetFilePath);
    }
}