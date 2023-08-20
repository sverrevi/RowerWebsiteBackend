using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs.GetDTOS;

namespace RowerWebsiteBackend.Services.RowingClubService
{
    public interface IRowingClubService
    {
        Task<ICollection<GetAllRowingClubsDTO>> GetAllRowingClubs();
        Task<RowingClub?> GetSingleRowingClub(int id);
        Task<ICollection<RowingClub>> AddRowingClub(RowingClub rowingClub);
        Task<bool> RowingClubExists(string clubName);
        Task<ICollection<RowingClub>?> UpdateRowingClub(int id, RowingClub rowingClub);
        Task<ICollection<RowingClub>?> DeleteRowingClub(int id);
    }
}
