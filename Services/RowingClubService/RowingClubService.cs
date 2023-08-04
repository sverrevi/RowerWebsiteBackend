using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Services.RowingClubService
{
    
    public class RowingClubService : IRowingClubService
    {

        private readonly DataContext _context;

        public RowingClubService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<RowingClub>> AddRowingClub(RowingClub rowingClub)
        {
            _context.RowingClubs.Add(rowingClub);
            await _context.SaveChangesAsync();
            return await _context.RowingClubs.ToListAsync();
        }

        public async Task<List<RowingClub>?> DeleteRowingClub(int id)
        {
            var rowingClub = await _context.RowingClubs.FindAsync(id);
            if (rowingClub == null)
                return null;

            _context.RowingClubs.Remove(rowingClub);

            await _context.SaveChangesAsync();
            return await _context.RowingClubs.ToListAsync();
        }

        public async Task<List<RowingClub?>> GetAllRowingClubs()
        {
            var rowingClubs = await _context.RowingClubs.ToListAsync();
            return rowingClubs;
        }

        public async Task<RowingClub?> GetSingleRowingClub(int id)
        {
            var rowingClub = await _context.RowingClubs.FindAsync(id);
            if (rowingClub == null)
                return null;

            return rowingClub;
        }

        public async Task<List<RowingClub>?> UpdateRowingClub(int id, RowingClub request)
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
