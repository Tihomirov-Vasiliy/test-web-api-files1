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
            string fileName = $"{Guid.NewGuid()}.txt";
            await _fileCreator.CreateAsync(Path.Combine(_fileDirectory, fileName), content);

            return fileName;
        }
    }
}
