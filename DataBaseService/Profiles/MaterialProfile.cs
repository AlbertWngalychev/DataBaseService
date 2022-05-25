using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialReadDto>();
            CreateMap<MaterialCreateDto, Material>();
        }
    }
}
