using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Models.DTOs
{
    public class RowingClubCreateDTO
    {
        public int Id { get; set; }
        public string? ClubName { get; set; }
        public string? ClubLocation { get; set; }
        public string? ClubWebsiteURL { get; set; }
        public List<Rower>? Members { get; set; }
    }
}
