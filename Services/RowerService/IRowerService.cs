using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;

namespace RowerWebsiteBackend.Services.RowerService
{
    public interface IRowerService
    {
        Task<ICollection<Rower>> GetAllRowers();
        Task<Rower?> GetOneRower(int id);
        Task<ICollection<Rower>> AddRower(Rower rower);
        Task<ICollection<Rower>?> UpdateRower(int id, Rower rower);
        Task<ICollection<Rower>?> DeleteRower(int id);
        //Task<ICollection<Rower>> AddRowingClubToRower(AddRowingClubToRowerDTO newRowingClub);


    }
}
