﻿namespace RowerWebsiteBackend.Models.Domain
{
    public class RowingClub
    {
        public int Id { get; set; }
        public string? ClubName { get; set; } = string.Empty;
        public string? ClubLocation { get; set; } = string.Empty;
        public string? ClubWebsiteURL { get; set; } = string.Empty;
        public string? ClubLogoFileName { get; set; } = "Some_string";

        //Relationship n:n
        public ICollection<Rower?>? Members { get; set; }
    }
}
