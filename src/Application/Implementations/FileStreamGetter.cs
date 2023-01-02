using Application.Interfaces;

namespace Application.Implementations
{
    public class FileGetter : IFileGetter
    {
        public FileStream GetStream(string filePath)
        {
            if (File.Exists(filePath))
                return File.OpenRead(filePath);
            else
                return null;
        }
    }
}
