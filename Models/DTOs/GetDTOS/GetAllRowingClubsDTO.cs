using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Models.DTOs.GetDTOS
{
    public class GetAllRowingClubsDTO
    {
        public string? ClubName { get; set; }
        public string? ClubLocation { get; set; }
        public string? ClubWebsiteURL { get; set; }
        public int? MemberCount { get; set; }
    }
}
