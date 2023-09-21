using Azure.Storage.Blobs;
using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Services
{
    public class FileService: IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Stream> GetImage(string name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("rowerphotos");
            var bloblInstance = containerInstance.GetBlobClient(name);
            var downloadContent = await bloblInstance.DownloadAsync();
            return downloadContent.Value.Content;
        }


    }
}
