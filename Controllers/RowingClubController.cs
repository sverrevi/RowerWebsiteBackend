using Microsoft.AspNetCore.Mvc;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Services.RowerService;
using RowerWebsiteBackend.Services.RowingClubService;

namespace RowerWebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowingClubController : ControllerBase
    {
        private readonly IRowingClubService _rowingClubService;
        public RowingClubController(IRowingClubService rowingClubService)
        {
            _rowingClubService = rowingClubService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RowingClub>>> GetAllRowingClubs()
        {
            return await _rowingClubService.GetAllRowingClubs();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RowingClub>> GetSingleRowingClub(int id)
        {
            var rowingClub = await _rowingClubService.GetSingleRowingClub(id);
            if (rowingClub == null)
            {
                return NotFound("This rowing club does not exist within the database");
            }
            return Ok(rowingClub);
        }
        [HttpPost]
        public async Task<ActionResult<List<RowingClub>>> AddRowingClub(RowingClub rowingClub)
        {
            var result = await _rowingClubService.AddRowingClub(rowingClub);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<RowingClub>>> UpdateRower(int id, RowingClub request)
        {
            var result = await _rowingClubService.UpdateRowingClub(id, request);
            if (result == null)
                return NotFound("Rowing club not found");

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RowingClub>>> DeleteRowingClub(int id)
        {
            var result = await _rowingClubService.DeleteRowingClub(id);
            if (result == null)
                return NotFound("Rower not found");

            return Ok(result);

        }
    }
}
