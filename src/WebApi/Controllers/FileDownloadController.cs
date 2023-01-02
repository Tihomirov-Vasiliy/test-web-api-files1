using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/filedownload")]
    [ApiVersion("1.0")]
    public class FileDownloadController : ControllerBase
    {
        private IFileGetService _getFileService;

        public FileDownloadController(IFileGetService getFileService)
        {
            _getFileService = getFileService;
        }

        [Authorize]
        [HttpGet(Name = "DownloadFile")]
        public IActionResult DownloadFile(string fileName)
        {
            Stream stream = _getFileService.GetStreamOfFile(fileName);

            return File(stream, "application/octet-stream", fileName, true);
        }

    }
}
