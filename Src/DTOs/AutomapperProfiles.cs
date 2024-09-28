using AutoMapper;
using ServerTest.Models;

namespace ServerTest.DTOs;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    { 
        CreateMap<Superhero, SuperheroDTO>().ReverseMap(); 
    }
}
