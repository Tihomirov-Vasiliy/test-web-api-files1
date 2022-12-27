using Application.Common.Interfaces;

namespace Application.Implementations
{
    public class FileContentGetter : IFileContentGetter
    {
        /// <summary>
        /// Represents async method to get file content (in bytes)
        /// </summary>
        /// <param name="filePath">Full path of file to get (it should contain file name and extension)</param>
        /// <returns>Content of file in bytes</returns>
        public async Task<byte[]> GetBytesOfFileAsync(string filePath)
        {
            if (File.Exists(filePath))
                return await File.ReadAllBytesAsync(filePath);
            else
                throw new FileNotFoundException($"File with name: {Path.GetFileName(filePath)} was not found");
        }
    }
}
