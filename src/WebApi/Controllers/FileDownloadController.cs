using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/v1/filedownload")]
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private IGetFileService _getFileService;

        public FileDownloadController(IGetFileService getFileService)
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
