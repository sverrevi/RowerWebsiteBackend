using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;

namespace RowerWebsiteBackend.Services.RowerService
{
    public class RowerService : IRowerService
    {


        private readonly DataContext _context;

        public RowerService(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Rower>> AddRower(Rower rower)
        {
            _context.Rowers.Add(rower);
            await _context.SaveChangesAsync();
            return await _context.Rowers.ToListAsync();
        }

        /*
        public async Task<ICollection<Rower>> AddRowingClubToRower(AddRowingClubToRowerDTO newRowingClub)
        {
            var response = new 
            _context.
        }
        */

        public async Task<ICollection<Rower>?> DeleteRower(int id)
        {
            var rower = await _context.Rowers.FindAsync(id);
            if (rower == null)
                return null;

            _context.Rowers.Remove(rower);

            await _context.SaveChangesAsync();
            return await _context.Rowers.ToListAsync();
        }

        public async Task<ICollection<Rower>> GetAllRowers()
        {
            var rowers = await _context.Rowers.ToListAsync();
            return rowers;
        }

        public async Task<Rower?> GetOneRower(int id)
        {
            var rower = await _context.Rowers.FindAsync(id);
            if (rower == null)
                return null;

            return rower;
        }

        public async Task<ICollection<Rower>?> UpdateRower(int id, Rower request)
        {
            var rower = await _context.Rowers.FindAsync(id);
            if (rower == null)
                return null;

            rower.FirstName = request.FirstName;
            rower.LastName = request.LastName;
            rower.Weight = request.Weight;
            rower.Height = request.Height;
            rower.RowingClub = request.RowingClub;
            rower.RowingClubs = request.RowingClubs;

            await _context.SaveChangesAsync();

            return await _context.Rowers.ToListAsync();
        }
    }
}
