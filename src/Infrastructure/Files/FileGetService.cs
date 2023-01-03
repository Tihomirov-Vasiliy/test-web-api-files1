using Application.Interfaces;
using Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using Infrastructure.Options;

namespace Infrastructure.Files
{
    public class FileGetService : IFileGetService
    {
        private IFileGetter _fileGetter;
        private string _filesDirectory;

        public FileGetService(IFileGetter fileGetter, IOptions<DirectoryOptions> directoryOptions)
        {
            _fileGetter = fileGetter;
            _filesDirectory = directoryOptions.Value.Location;
        }

        public Stream GetStreamOfFile(string fileName)
        {
            Stream fileStream = _fileGetter.GetStream(Path.Combine(_filesDirectory, fileName));

            return fileStream;
        }
    }
}