using Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using Services.Options;

namespace Services.Implementations
{
    public class CreateFileService : ICreateFileService
    {
        private IFileCreator _fileCreator;
        private string _fileDirectory;

        public CreateFileService(IFileCreator fileCreator, IOptions<DirectoryOptions> directoryOptions)
        {
            _fileCreator = fileCreator;
            _fileDirectory = directoryOptions.Value.Location;
        }
        public async Task<string> CreateFileAsync(string content)
        {
            string fileName = Guid.NewGuid().ToString();
            await _fileCreator.CreateFileAsync($"{_fileDirectory}\\{fileName}.txt", content);

            return fileName;
        }
    }
}
