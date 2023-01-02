using Application.Interfaces;

namespace Application.Implementations
{
    public class FileCreator : IFileCreator
    {
        public async Task CreateAsync(string filePath, string content)
        {
            await File.WriteAllTextAsync(filePath, content);
        }
    }
}
