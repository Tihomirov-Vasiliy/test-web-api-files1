using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/filedownload")]
    [ApiController]
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
            FileStream stream = _getFileService.GetStreamOfFile(fileName);

            return File(stream, "application/octet-stream", fileName, true);
        }

    }
}
