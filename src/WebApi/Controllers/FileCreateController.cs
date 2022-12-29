using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/v1/filecreate")]
    [ApiController]
    public class FileCreateController : ControllerBase
    {
        private ICreateFileService _createFileService;

        public FileCreateController(ICreateFileService createFileService)
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
