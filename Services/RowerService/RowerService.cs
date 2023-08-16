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

        public async Task<Rower> AddRower(Rower rower)
        {
            foreach (var rowingClub in rower.RowingClubs)
            {
                var existingRowingClub = await _context.RowingClubs.FirstOrDefaultAsync(rc => rc.ClubName == rowingClub.ClubName);

                if (existingRowingClub == null)
                {
                    // Rowing club doesn't exist, return without adding the rower
                    return null;
                }

            }

            rower.RowingClubs = rower.RowingClubs
            .Select(rc => _context.RowingClubs.Local
            .FirstOrDefault(existingClub => existingClub.ClubName == rc.ClubName))
            .ToList();

            _context.Rowers.Add(rower);
            await _context.SaveChangesAsync();
            return rower;
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

        public async Task<Rower>? UpdateRower(int id, Rower request)
        {

            Rower rowerToUpdate = await _context.Rowers
                .Include(c => c.RowingClubs)
                .Where(c => c.Id == id)
                .FirstAsync();

            if (rowerToUpdate == null)
                return null;

            List<RowingClub> clubs = new();
            foreach (RowingClub rowingClub in rowerToUpdate.RowingClubs)
            {
                RowingClub? club = await _context.RowingClubs.FindAsync(rowingClub.Id);
                if (club == null)
                    return null;
                clubs.Add(club);
            }
            rowerToUpdate.FirstName = request.FirstName;
            rowerToUpdate.LastName = request.LastName;
            rowerToUpdate.Gender= request.Gender;
            rowerToUpdate.Weight = request.Weight;
            rowerToUpdate.Height = request.Height;
            rowerToUpdate.RowingClubs = clubs;

            await _context.SaveChangesAsync();

            return rowerToUpdate;
        }
    }
}
