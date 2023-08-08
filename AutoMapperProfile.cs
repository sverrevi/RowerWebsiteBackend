using AutoMapper;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs;

namespace RowerWebsiteBackend
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //RowerMaps
            CreateMap<Rower, RowerDTO>();
            CreateMap<RowerDTO, Rower>();

            //RowingClubMaps
            CreateMap<RowingClub, RowingClubDTO>();
            CreateMap<RowingClubDTO, RowingClub>();
        }
    }
}
