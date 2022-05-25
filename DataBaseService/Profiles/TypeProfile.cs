using AutoMapper;
using DataBaseService.Dtos;

namespace DataBaseService.Profiles
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<Models.Type, TypeReadDto>();
            CreateMap<TypeCreateDto, Models.Type>();
        }
    }
}
