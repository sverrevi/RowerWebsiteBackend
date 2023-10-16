using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;
using RowerWebsiteBackend.Models.DTOs.GetDTOS;

namespace RowerWebsiteBackend.Services.RowingClubService
{
    
    public class RowingClubService : IRowingClubService
    {

        private readonly DataContext _context;

        public RowingClubService(DataContext context)
        {
            _context = context;
        }


        public async Task<bool> RowingClubExists(string clubName)
        {
            return await _context.RowingClubs.AnyAsync(rc => rc.ClubName == clubName);
        }
        public async Task<ICollection<RowingClub>> AddRowingClub(RowingClub rowingClub)
        {
            _context.RowingClubs.Add(rowingClub);
            await _context.SaveChangesAsync();
            return await _context.RowingClubs.ToListAsync();
        }

        public async Task<ICollection<RowingClub>?> DeleteRowingClub(int id)
        {
            var rowingClub = await _context.RowingClubs.FindAsync(id);
            if (rowingClub == null)
                return null;

            _context.RowingClubs.Remove(rowingClub);

            await _context.SaveChangesAsync();
            return await _context.RowingClubs.ToListAsync();
        }

        public async Task<ICollection<GetAllRowingClubsDTO>> GetAllRowingClubs()
        {
            var rowingClubs = await _context.RowingClubs
            .Include(rc => rc.Members)
            .ToListAsync();

            var dtoList = rowingClubs.Select(rc => new GetAllRowingClubsDTO
            {
                ClubName = rc.ClubName,
                ClubLocation = rc.ClubLocation,
                ClubWebsiteURL = rc.ClubWebsiteURL,
                MemberCount = rc.Members.Count(),
                ClubLogoFileName = rc.ClubLogoFileName,
            }).ToList();

            return dtoList;
        }

        public async Task<RowingClub?> GetSingleRowingClub(int id)
        {
            var rowingClub = await _context.RowingClubs
                .Include(c => c.Members)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (rowingClub == null)
                return null;

            return rowingClub;
        }

        public async Task<ICollection<RowingClub>?> UpdateRowingClub(int id, RowingClub request)
        {
            var rowingClub = await _context.RowingClubs.FindAsync(id);
            if (rowingClub == null)
                return null;

            rowingClub.ClubLocation = request.ClubLocation;
            rowingClub.ClubName = request.ClubName;
            rowingClub.ClubWebsiteURL = request.ClubWebsiteURL;
            rowingClub.Members = request.Members;

            await _context.SaveChangesAsync();

            return await _context.RowingClubs.ToListAsync();
        }


    }
    
}
