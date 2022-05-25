using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class OrderElementProfile : Profile
    {
        public OrderElementProfile()
        {
            CreateMap<OrderElement, OrderElementReadDto>();
            CreateMap<OrderElementCreateDto, OrderElement>();

        }
    }
}
