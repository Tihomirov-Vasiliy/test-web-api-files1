using Application.Common.Interfaces;

namespace Application.Implementations
{
    public class FileCreator : IFileCreator
    {
        /// <summary>
        /// Represents async method to create txt file
        /// </summary>
        /// <param name="filePath">Full path to store file (it should contain file name and extension)</param>
        /// <param name="content">Content of file</param>
        /// <returns>Name of file</returns>
        public async Task CreateFileAsync(string filePath, string content)
        {
            await File.WriteAllTextAsync(filePath, content);
        }
    }
}
