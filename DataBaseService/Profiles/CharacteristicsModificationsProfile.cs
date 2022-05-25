using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class CharacteristicsModificationsProfile : Profile
    {
        public CharacteristicsModificationsProfile()
        {
            CreateMap<CharacteristicsModification, CharacteristicsModificationsReadDto>();
            CreateMap<CharacteristicsModificationsCreateDto, CharacteristicsModification>();
        }
    }
}
