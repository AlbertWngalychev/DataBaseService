using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class ModifProfile : Profile
    {
        public ModifProfile()
        {
            CreateMap<Mdification, ModifReadDto>();
            CreateMap<ModifCreateDto, Mdification>();
        }
    }
}
