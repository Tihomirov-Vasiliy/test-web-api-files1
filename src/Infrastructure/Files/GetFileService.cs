using Application.Interfaces;
using Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using Infrastructure.Options;

namespace Infrastructure.Files
{
    public class GetFileService : IFileGetService
    {
        private IFileGetter _fileGetter;
        private string _filesDirectory;

        public GetFileService(IFileGetter fileGetter, IOptions<DirectoryOptions> directoryOptions)
        {
            _fileGetter = fileGetter;
            _filesDirectory = directoryOptions.Value.Location;
        }

        public FileStream GetStreamOfFile(string fileName)
        {
            FileStream fileStream = _fileGetter.GetStream(Path.Combine(_filesDirectory, fileName));

            if (fileStream == null)
                throw new FileNotFoundException($"File with name '{fileName}' was not found in directory");

            return fileStream;
        }
    }
}