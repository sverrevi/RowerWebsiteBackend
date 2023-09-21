using Microsoft.AspNetCore.Mvc;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Services;

namespace RowerWebsiteBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(string name)
        {
            var imageFileStream = await _fileService.GetImage(name);
            string fileType = "jpg";
            if (name.Contains("png"))
            {
                fileType = "png";
            }
            return File(imageFileStream, $"image/{fileType}");
        }
    }
}
