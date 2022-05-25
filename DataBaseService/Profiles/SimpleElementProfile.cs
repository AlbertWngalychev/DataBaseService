using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class SimpleElementProfile : Profile
    {
        public SimpleElementProfile()
        {
            CreateMap<Category, SimpleElementReadDto>();
            CreateMap<Gender, SimpleElementReadDto>();
            CreateMap<Cloth, SimpleElementReadDto>();
            CreateMap<Value, SimpleElementReadDto>()
                .ForMember(dto => dto.Name, val => val.MapFrom(x => x.Value1));
            CreateMap<Status, SimpleElementReadDto>();
            CreateMap<Chatacteristic, SimpleElementReadDto>();
        }
    }
}
