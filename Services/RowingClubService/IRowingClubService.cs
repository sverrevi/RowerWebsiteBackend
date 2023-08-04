using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Services.RowingClubService
{
    public interface IRowingClubService
    {
        Task<List<RowingClub>> GetAllRowingClubs();
        Task<RowingClub?> GetSingleRowingClub(int id);
        Task<List<RowingClub>> AddRowingClub(RowingClub rowingClub);
        Task<List<RowingClub>?> UpdateRowingClub(int id, RowingClub rowingClub);
        Task<List<RowingClub>?> DeleteRowingClub(int id);
    }
}
