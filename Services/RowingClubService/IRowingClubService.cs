using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Services.RowingClubService
{
    public interface IRowingClubService
    {
        Task<ICollection<RowingClub>> GetAllRowingClubs();
        Task<RowingClub?> GetSingleRowingClub(int id);
        Task<ICollection<RowingClub>> AddRowingClub(RowingClub rowingClub);
        Task<ICollection<RowingClub>?> UpdateRowingClub(int id, RowingClub rowingClub);
        Task<ICollection<RowingClub>?> DeleteRowingClub(int id);
    }
}
