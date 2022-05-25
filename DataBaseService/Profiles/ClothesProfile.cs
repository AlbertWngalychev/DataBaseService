using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class ClothesProfile : Profile
    {
        public ClothesProfile()
        {
            CreateMap<Сlothe, ClothesReadDto>();
            CreateMap<ClothesCreatDto, Сlothe>();
        }
    }
}
