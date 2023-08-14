using Microsoft.AspNetCore.Http.HttpResults;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;
using System.Data;

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

        
        public async Task<Rower> UpdateRowingClubsForRower(int id, List<int> rowingClubs)
        {
            Rower rowerToUpdate = await _context.Rowers
                .Include(c => c.RowingClubs)
                .Where(c => c.Id == id)
                .FirstAsync();

            List<RowingClub> clubs = new();
            foreach (int rowingClubId in rowingClubs)
            {
                RowingClub? club = await _context.RowingClubs.FindAsync(rowingClubId);
                if (club == null)
                    return null;
                clubs.Add(club);
            }

            rowerToUpdate.RowingClubs = clubs;

            try
            {
                await _context.SaveChangesAsync();
                return rowerToUpdate;
            }
            catch(DbUpdateConcurrencyException) 
            {
                throw;
            }
        }
        

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
            var rowers = await _context.Rowers.Include(c => c.RowingClubs).ToListAsync();
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
