using Application.Interfaces;
using Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using Infrastructure.Options;

namespace Infrastructure.Files
{
    public class CreateTxtFileService : IFileCreateService
    {
        private IFileCreator _fileCreator;
        private string _fileDirectory;

        public CreateTxtFileService(IFileCreator fileCreator, IOptions<DirectoryOptions> directoryOptions)
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