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
        [HttpPost("upload/{id}")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            var result = await _fileService.UploadImage(file, id);

            if (result == null)
            {
                return NotFound($"Rower with ID {id} not found.");
            }

            return Ok("Image uploaded successfully.");
        }
        
        [HttpPost("uploadLogo/{id}")]
        public async Task<IActionResult> UploadRowingClubLogo(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            var result = await _fileService.UploadRowingClubLogo(file, id);

            if (result == null)
            {
                return NotFound($"RowingClub with ID {id} not found.");
            }

            return Ok("Image uploaded successfully.");
        }
        
    }
}
