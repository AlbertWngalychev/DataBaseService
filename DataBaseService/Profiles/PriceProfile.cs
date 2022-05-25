using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<Price, PriceReadDto>();
            CreateMap<PriceCreateDto, Price>();
        }
    }
}
