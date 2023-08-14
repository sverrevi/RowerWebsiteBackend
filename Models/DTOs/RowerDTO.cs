using RowerWebsiteBackend.Models.Domain;

namespace RowerWebsiteBackend.Models.DTOs
{
    public class RowerDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public ICollection<RowingClubDTO>? RowingClubs { get; set; }
    }
}
