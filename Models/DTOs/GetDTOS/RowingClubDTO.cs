using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Models.DTOs.GetDTOS
{
    public class RowingClubDTO
    {
        public string? ClubName { get; set; }
        public string? ClubLocation { get; set; }
        public string? ClubWebsiteURL { get; set; }
    }
}
