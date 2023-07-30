namespace Sunburst.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sunburst.Models.Storage;
    using Sunburst.Services.Contracts;
    using System.Reflection.Metadata;

    [Route("blobs")]
    public class BlobStorageController : Controller
    {
        private readonly IBlobService _blobService;

        public BlobStorageController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet("{blobName}")] 
        public async Task<IActionResult> GetBlob(string blobName)
        {
            var data = await _blobService.GetBlobAsync(blobName);

            return File(data.Content, data.ContentType);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            return Ok(await _blobService.ListBlobsAsync());
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest request)
        { 
            await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }

        [HttpPost("uploadContent")]
        public async Task<IActionResult> UploadContent([FromBody] UploadContentRequest request)
        {
            await _blobService.UploadContentBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await _blobService.DeleteBlobAsync(blobName);
            return Ok();
        }
    }
}
