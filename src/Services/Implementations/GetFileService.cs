using Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using Services.Options;

namespace Services.Implementations
{
    public class GetFileService : IGetFileService
    {
        private IFileStreamGetter _fileGetter;
        private string _filesDirectory;

        public GetFileService(IFileStreamGetter fileGetter, IOptions<DirectoryOptions> directoryOptions)
        {
            _fileGetter = fileGetter;
            _filesDirectory = directoryOptions.Value.Location;
        }

        public FileStream GetStreamOfFile(string fileName)
        {
            FileStream fileStream = _fileGetter.Get(Path.Combine(_filesDirectory, fileName));
            if (fileStream == null)
                throw new FileNotFoundException(fileName);

            return fileStream;
        }
    }
}
