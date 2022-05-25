using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class CharacteristicsValueProfile : Profile
    {
        public CharacteristicsValueProfile()
        {
            CreateMap<ChatacteristicsValue, CharacteristicsValueReadDto>();
            CreateMap<CharacteristicsValueCreateDto, ChatacteristicsValue>();
        }
    }
}
