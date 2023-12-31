﻿namespace RowerWebsiteBackend.Services
{
    public interface IFileService
    {
        Task<Stream> GetImage(string name);
        Task<string?> UploadImage(IFormFile file, int id);
        Task<string?> UploadRowingClubLogo(IFormFile file, int id);
    }
}
