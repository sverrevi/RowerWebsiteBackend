using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;

namespace RowerWebsiteBackend.Services.RowerService
{
    public interface IRowerService
    {
        Task<ICollection<Rower>> GetAllRowers();
        Task<Rower?> GetOneRower(int id);
        Task<Rower> AddRower(Rower rower);
        Task<Rower>? UpdateRower(int id, Rower rower);
        Task<ICollection<Rower>?> DeleteRower(int id);
        Task<Rower> UpdateRowingClubsForRower(int id, List<int> rowingClubs);


    }
}
