using Domain;
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

        [HttpGet(Name = "DownloadFileAsync")]
        public async Task<ActionResult> DownloadFileAsync(string fileName)
        {
            //I think here i can return BaseFile entity and get from it content and filename with correct extension
            byte[] content = await _getFileService.GetFileAsync(fileName);

            return File(content, "text/plain", fileName);
        }
    }
}
