using AutoMapper;
using RowerWebsiteBackend.Models.Domain;
using RowerWebsiteBackend.Models.DTOs.GetDTOS;
using RowerWebsiteBackend.Models.DTOs.PostDTOS;

namespace RowerWebsiteBackend
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //RowerMaps
            CreateMap<Rower, RowerDTO>();
            CreateMap<RowerDTO, Rower>();
            CreateMap<Rower, PostRowerDTO>();
            CreateMap<PostRowerDTO, Rower>();

            //RowingClubMaps
            CreateMap<RowingClub, RowingClubDTO>();
            CreateMap<RowingClubDTO, RowingClub>();
            CreateMap<RowingClub, ExistingRowingClubToRowerDTO>();
            CreateMap<ExistingRowingClubToRowerDTO, RowingClub>();

            //Maping between
            CreateMap<GetAllRowingClubsDTO,RowingClub>();
            CreateMap<RowingClub, GetAllRowingClubsDTO>();


        }
    }
}
