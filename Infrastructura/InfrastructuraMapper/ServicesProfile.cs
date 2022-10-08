using AutoMapper;
using Domain.Dtos;
using Domain.Entites;

namespace Infrastructura.InfrastructuraMapper;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        CreateMap<Chalange, GetChalangeDto>();
        CreateMap<Group, GetGroupDto>();
        CreateMap<Location, AddLocationDto>();
    }
}
