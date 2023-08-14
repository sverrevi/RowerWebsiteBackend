using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;
using RowerWebsiteBackend.Services.RowerService;
using RowerWebsiteBackend.Services.RowingClubService;

namespace RowerWebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowingClubController : ControllerBase
    {
        private readonly IRowingClubService _rowingClubService;
        private readonly IMapper _mapper;
        public RowingClubController(IRowingClubService rowingClubService, IMapper mapper)
        {
            _rowingClubService = rowingClubService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RowingClub>>> GetAllRowingClubs()
        {
            return Ok(_mapper.Map<List<RowingClubDTO>>(await _rowingClubService.GetAllRowingClubs()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RowingClub>> GetSingleRowingClub(int id)
        {
            var rowingClub = _mapper.Map<RowingClub>(await _rowingClubService.GetSingleRowingClub(id));
            if (rowingClub == null)
            {
                return NotFound("This rowing club does not exist within the database");
            }
            return Ok(rowingClub);
        }
        [HttpPost]
        public async Task<ActionResult<List<RowingClub>>> AddRowingClub(RowingClubDTO rowingClubDTO)
        {
            if (await _rowingClubService.RowingClubExists(rowingClubDTO.ClubName))
            {
                return BadRequest("A rowing club with this name already exists.");
            }
            RowingClub rowingClub = _mapper.Map<RowingClub>(rowingClubDTO);
            var result = await _rowingClubService.AddRowingClub(rowingClub);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<RowingClub>>> UpdateRower(int id, RowingClubDTO rowingClubDTO)
        {
            RowingClub rowingClub = _mapper.Map<RowingClub>(rowingClubDTO);
            var result = await _rowingClubService.UpdateRowingClub(id, rowingClub);
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
