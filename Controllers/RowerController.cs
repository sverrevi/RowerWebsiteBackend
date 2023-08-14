using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;
using RowerWebsiteBackend.Services.RowerService;

namespace RowerWebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowerController : ControllerBase
    {
        private readonly IRowerService _rowerService;
        private readonly IMapper _mapper;

        public RowerController(IRowerService rowerService, IMapper mapper) 
        {
            _rowerService = rowerService;
            _mapper = mapper;
        }
       

        
        [HttpGet]
        public async Task<ActionResult<List<RowerDTO>>> GetAllRowers()
        {
            return Ok(_mapper.Map<List<RowerDTO>>(await _rowerService.GetAllRowers()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rower>> GetOneRower(int id)
        {
            var rower = _mapper.Map<RowerDTO>(await _rowerService.GetOneRower(id));
            if (rower == null)
            {
                return NotFound("This rower does not exist within the database");
            }
            return Ok(rower);
        }

        [HttpPost]
        public async Task<ActionResult<List<Rower>>> AddRower([FromBody] RowerDTO rowerDTO)
        {
            Rower rower = _mapper.Map<Rower>(rowerDTO);
            var result = await _rowerService.AddRower(rower);
            return Ok(result);
        }


        [HttpPut("{id}/update-rowing-clubs-on-rower")]
        public async Task<IActionResult> UpdateRowingClubsForRower(int id, [FromBody] List<int> rowingClubIds)
        {
            if (rowingClubIds == null || rowingClubIds.Count == 0)
                return BadRequest("List of rowing club IDs must be provided.");
            try
            {
                Rower updatedRower = await _rowerService.UpdateRowingClubsForRower(id, rowingClubIds);
                if (updatedRower == null)
                    return BadRequest("One or more rowing club IDs are invalid.");

                return Ok(updatedRower);
            }

            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database update error.");
            }

        }
        
        

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Rower>>> UpdateRower(int id, RowerDTO rowerDTO)
        {
            Rower rower = _mapper.Map<Rower>(rowerDTO);
            var result =  await _rowerService.UpdateRower(id, rower);
            if (result == null)
                return NotFound("Rower not found");

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Rower>>> DeleteRower(int id)
        {
            var result = await _rowerService.DeleteRower(id);
            if (result == null)
                return NotFound("Rower not found");

            return Ok(result);

        }

    }
}

