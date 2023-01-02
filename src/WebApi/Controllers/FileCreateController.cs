using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/filecreate")]
    [ApiVersion("1.0")]
    public class FileCreateController : ControllerBase
    {
        private IFileCreateService _createFileService;

        public FileCreateController(IFileCreateService createFileService)
        {
            _createFileService = createFileService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateFileAsync([FromBody] FileContentDto fileContent)
        {
            string resultedFileName = await _createFileService.CreateFileAsync(fileContent.Text);
            
            return CreatedAtRoute("DownloadFile", resultedFileName);
        }
    }
}
