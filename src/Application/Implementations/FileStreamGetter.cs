using Application.Common.Interfaces;

namespace Application.Implementations
{
    public class FileStreamGetter : IFileStreamGetter
    {
        /// <summary>
        /// Represents method to get Stream of file by its path
        /// </summary>
        /// <param name="filePath">Full path to file</param>
        /// <returns></returns>
        public FileStream Get(string filePath)
        {
            if (File.Exists(filePath))
                return File.OpenRead(filePath);
            else
                return null;
        }
    }
}
