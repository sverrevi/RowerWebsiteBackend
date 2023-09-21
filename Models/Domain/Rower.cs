using RowerWebsiteBackend.Models.Enums;

namespace RowerWebsiteBackend.Models.Domain
{
    public class Rower
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public string PhotoUrl { get; set; } = "default-photo-url.jpg";
        public string? PhotoFileName { get; set; }

        //Relationship n:n
        public ICollection<RowingClub>? RowingClubs { get; set; }

    }
}
