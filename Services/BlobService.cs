namespace Sunburst.Services
{
    using Azure.Storage.Blobs;
    using Sunburst.Models.Storage;
    using Sunburst.Services.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BlobService : IBlobService
    {

        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<BlobInfo> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images"); //testing container "images"/// change with name later
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClient.DownloadContentAsync();
            return new BlobInfo(blobDownloadInfo.Value.Content.ToStream(), blobDownloadInfo.Value.Details.ToString());
        }

        public Task<IEnumerable<string>> ListBlobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UploadContentBlobAsync(string content, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task UploadFileBlobAsync(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBlobAsync(string blobName)
        {
            throw new NotImplementedException();
        }
    }
}
