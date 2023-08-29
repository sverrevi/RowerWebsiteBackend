using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.Enums;

namespace RowerWebsiteBackend.Models.DTOs.GetDTOS
{
    public class RowerDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;

        public ICollection<RowingClubDTO>? RowingClubs { get; set; }
    }
}
