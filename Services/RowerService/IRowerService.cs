using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Services.RowerService
{
    public interface IRowerService
    {
        Task<List<Rower>> GetAllRowers();
        Task<Rower?> GetOneRower(int id);
        Task<List<Rower>> AddRower(Rower rower);
        Task<List<Rower>?> UpdateRower(int id, Rower rower);
        Task<List<Rower>?> DeleteRower(int id);

    }
}
