using AkGames.Api.Core.Models;
using AkGames.Api.Dtos;
using AutoMapper;

namespace AkGames.Api.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameGitDto>()
                .ForMember(dest => dest.SelectedDevices, src => src.MapFrom(src => src.Devices.Select(x => x.DeviceId)))
                .ForMember(dest => dest.CoverUrl, src => src.MapFrom(src => src.Cover));

            CreateMap<Category, CategoryGitDto>();

        }
    }
}
