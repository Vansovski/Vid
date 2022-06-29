using AutoMapper;
using Vidly.App.Dtos;
using Vidly.Models;

namespace Vidly.App.Helpers
{
    public class MappingProfile: Profile
    {
         public MappingProfile()
        {
            CreateMap<Cliente,ClienteDto>().ReverseMap();
        }
        
    }
}
