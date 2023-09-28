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
            var rowerToApplyImageTo = await _context.Rowers
                .FirstOrDefaultAsync(r => r.Id == rowerId);

            if (rowerToApplyImageTo == null)
            {
                return null;
            }

            string fileName = $"{rowerToApplyImageTo.FirstName}{rowerToApplyImageTo.LastName}_{DateTime.Now.Ticks}.jpg";

            var containerClient = _blobServiceClient.GetBlobContainerClient("rowerphotos");
            var blobClient = containerClient.GetBlobClient(fileName);

            using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            rowerToApplyImageTo.PhotoFileName = fileName;
            await _context.SaveChangesAsync();

            return fileName;
        }
        
        public async Task<string?> UploadRowingClubLogo(IFormFile formFile, int rowingClubId)
        {
            var rowingClubToApplyLogoTo = await _context.RowingClubs
                .FirstOrDefaultAsync(r => r.Id == rowingClubId);

            if (rowingClubToApplyLogoTo == null)
            {
                return null;
            }

            string fileName = $"{rowingClubToApplyLogoTo.ClubName}Logo_{DateTime.Now.Ticks}.jpg";

            var containerClient = _blobServiceClient.GetBlobContainerClient("rowerphotos");
            var blobClient = containerClient.GetBlobClient(fileName);

            using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            rowingClubToApplyLogoTo.ClubLogoFileName = fileName;
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
