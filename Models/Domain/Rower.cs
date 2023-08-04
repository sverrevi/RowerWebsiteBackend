namespace RowerWebsiteBackend.Models.Domain
{
    public class Rower
    {
        //PK
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RowingClub { get; set; } = string.Empty;
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;

        //Relationships n:n
        public ICollection<RowingClub>? RowingClubs { get; set; }

    }
}
