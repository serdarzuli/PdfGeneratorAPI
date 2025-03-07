using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using PdfGeneratorAPI.Repository.Interfaces;

namespace PdfGeneratorAPI.BLL.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadAsyncStream(Stream file, string container, string? filename = null, string? fileType = "application/pdf")
        {
            if (file.Length == 0)
            {
                throw new ArgumentException("FileLengthError");
            }

            string name = Guid.NewGuid().ToString();
            if (filename != null)
            {
                name = filename;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient(container);
            var blobClient = containerClient.GetBlobClient(name);
            await blobClient.UploadAsync(file, new BlobHttpHeaders { ContentType = fileType });
            return blobClient.Uri.ToString();


        }
    }
}
