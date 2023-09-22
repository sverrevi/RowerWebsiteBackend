using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Services
{
    public class FileService: IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly DataContext _context;
        public FileService(BlobServiceClient blobServiceClient, DataContext context)
        {
            _blobServiceClient = blobServiceClient;
            _context = context;
        }

        public async Task<string?> UploadImage(IFormFile formFile, int rowerId)
        {
            // Retrieve the rower by ID
            var rowerToApplyImageTo = await _context.Rowers
                .FirstOrDefaultAsync(r => r.Id == rowerId);

            if (rowerToApplyImageTo == null)
            {
                return null; // Rower not found
            }

            // Generate a unique filename for the image (e.g., rower's name + timestamp)
            string fileName = $"{rowerToApplyImageTo.FirstName}{rowerToApplyImageTo.LastName}_{DateTime.Now.Ticks}.jpg";

            var containerClient = _blobServiceClient.GetBlobContainerClient("rowerphotos");
            var blobClient = containerClient.GetBlobClient(fileName);

            using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true); // Upload the image to Azure Blob Storage
            }

            // Update the rower's PhotoFileName property with the uploaded filename
            rowerToApplyImageTo.PhotoFileName = fileName;
            await _context.SaveChangesAsync();

            return fileName;
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
