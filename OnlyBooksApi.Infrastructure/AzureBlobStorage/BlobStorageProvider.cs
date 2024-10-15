using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using OnlyBooksApi.Application.Interfaces.Providers;

namespace OnlyBooksApi.Infrastructure.AzureBlobStorage
{
    public class BlobStorageProvider : IBlobStorageProvider
    {
        private string ContainerName { get; set; } = "onlybooksimagescontainer";
        private BlobServiceClient _blobServiceClient { get; set; }
        private BlobContainerClient _blobContainerClient { get; set; }

        public BlobStorageProvider(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
            _blobContainerClient.CreateIfNotExists();
        }

        public async Task UploadFile(IFormFile file, string filename)
        {
            var blobClient = _blobContainerClient.GetBlobClient(filename);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType,

            };

            await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
        }

        public string GetFile(string fileName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);

            var fileExist = blobClient.Exists();

            if (fileExist.Value)
            {
                return blobClient.Uri.AbsoluteUri;
            }

            return null;
        }
    }
}
