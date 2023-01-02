using Application.Interfaces;
using Application.Interfaces.Services;
using Infrastructure.Files;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Infrastructure.Files
{
    public class GetFileService_GetStreamOfFile
    {
        private IFileGetService _fileGetService;
        private Mock<IFileGetter> _fileGetterMock;
        private IOptions<DirectoryOptions> _directoryOptionsMock;
        public GetFileService_GetStreamOfFile()
        {
            _fileGetterMock = new Mock<IFileGetter>();
            _directoryOptionsMock = Options.Create<DirectoryOptions>(new DirectoryOptions() { Location=""});
        }
        [Fact]
        public void GetStreamOfFile_ReturnsStreamDerivedType()
        {
            string filePath = "exitstingFile.txt";
            //Stream.Null returns Stream but not null
            _fileGetterMock.Setup(x => x.GetStream(filePath)).Returns(Stream.Null);
            _fileGetService = new FileGetService(_fileGetterMock.Object, _directoryOptionsMock);

            Assert.IsAssignableFrom<Stream>(_fileGetService.GetStreamOfFile(filePath));
        }

        [Fact]
        public void GetStreamOfFile_ThrowsFileNotFoundException()
        {
            string filePath = "somefile.txt";
            _fileGetterMock.Setup(x => x.GetStream(filePath)).Returns((Stream)null);
            _fileGetService = new FileGetService(_fileGetterMock.Object, _directoryOptionsMock);

            Assert.Throws<FileNotFoundException>(() => _fileGetService.GetStreamOfFile(filePath));
        }
    }
}
