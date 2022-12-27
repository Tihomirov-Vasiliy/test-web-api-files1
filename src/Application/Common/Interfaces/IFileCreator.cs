namespace Application.Common.Interfaces
{
    public interface IFileCreator
    {
        Task CreateFileAsync(string filePath, string content);
    }
}
