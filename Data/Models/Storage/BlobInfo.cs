namespace Sunburst.Data.Models.Storage
{
    public class BlobInfo
    {

        public BlobInfo(Stream content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }

        public Stream Content { get; set; }

        public string ContentType { get; set; }
    }
}
