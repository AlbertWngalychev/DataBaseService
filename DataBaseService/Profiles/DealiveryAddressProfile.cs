using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class DealiveryAddressProfile : Profile
    {
        public DealiveryAddressProfile()
        {
            CreateMap<DeliveryAddress, DeliveryAddressReadDto>();
            CreateMap<DeliveryAddressCreateDto, DeliveryAddress>();
        }
    }
}
