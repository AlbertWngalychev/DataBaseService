using AutoMapper;
using DataBaseService.Dtos;
using DataBaseService.Models;

namespace DataBaseService.Profiles
{

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientReadDto>();
            CreateMap<ClientCreateDto, Client>();
        }
    }
}
