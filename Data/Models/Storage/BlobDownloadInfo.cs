namespace Sunburst.Data.Models.Storage
{
    using Azure.Storage.Blobs.Models;

    public class BlobDownloadInfo
    {
        public BlobDownloadInfo(BinaryData content, BlobDownloadDetails details)
        {
            Content = content;
            Details = details;
        }

        public BinaryData Content { get; }

        public BlobDownloadDetails Details { get; }
    }
}
