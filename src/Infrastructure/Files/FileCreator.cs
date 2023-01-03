using Application.Interfaces;

namespace Infrastructure.Files
{
    public class FileCreator : IFileCreator
    {
        public Task CreateAsync(string filePath, string content)
        {
             return File.WriteAllTextAsync(filePath, content);
        }
    }
}
