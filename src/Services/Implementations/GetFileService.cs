using Application.Common.Interfaces;
using Domain.Exceptions;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using Services.Options;

namespace Services.Implementations
{
    public class GetFileService : IGetFileService
    {
        private IFileContentGetter _fileGetter;
        private string _filesDirectory;

        public GetFileService(IFileContentGetter fileGetter, IOptions<DirectoryOptions> directoryOptions)
        {
            _fileGetter = fileGetter;
            _filesDirectory = directoryOptions.Value.Location;
        }
        public async Task<byte[]> GetFileAsync(string fileName)
        {
            string resultFileName;
            string extension = null;
            int length = fileName.Length;

            for (int i = length; --i >= 0;)
                if (fileName[i] == '.')
                {
                    extension = fileName.Substring(i, length - i);
                    break;
                }

            if (extension == null)
                resultFileName = $"{fileName}.txt";
            else if (extension == ".txt")
                resultFileName = fileName;
            else
                throw new WrongFileExtensionException($"You're using extension - {extension}, try to use (.txt) or filename without extensions");

            return await _fileGetter.GetBytesOfFileAsync($"{_filesDirectory}\\{resultFileName}");
        }
    }
}
