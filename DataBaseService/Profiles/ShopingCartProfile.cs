using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class ShopingCartProfile : Profile
    {
        public ShopingCartProfile()
        {
            CreateMap<ShopingCart, ShopingCartReadDto>();
            CreateMap<ShopingCartCreateDto, ShopingCart>();
        }
    }
}
