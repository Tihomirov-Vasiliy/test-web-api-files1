namespace Application.Interfaces
{
    public interface IFileCreator
    {
        Task CreateAsync(string filePath, string content);
    }
}
