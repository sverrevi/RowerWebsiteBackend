namespace RowerWebsiteBackend.Services
{
    public interface IFileService
    {
        Task<Stream> GetImage(string name);
    }
}
