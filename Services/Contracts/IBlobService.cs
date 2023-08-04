namespace Sunburst.Services.Contracts
{
    using Sunburst.Data.Models.Storage;

    public interface IBlobService
    {
        Task<BlobInfo> GetBlobAsync(string name);

        Task<IEnumerable<string>> ListBlobsAsync();

        Task UploadFileBlobAsync(string filePath, string fileName);

        Task UploadContentBlobAsync(string content, string fileName);

        Task DeleteBlobAsync(string blobName);
    }
}
