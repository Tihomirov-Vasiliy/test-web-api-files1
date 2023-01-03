using Application.Interfaces;

namespace Infrastructure.Files
{
    public class FileGetter : IFileGetter
    {
        public Stream GetStream(string filePath)
        {
            if (File.Exists(filePath))
                return File.OpenRead(filePath);
            else
                throw new FileNotFoundException($"File with name '{Path.GetFileName(filePath)}' was not found in directory");
        }
    }
}
