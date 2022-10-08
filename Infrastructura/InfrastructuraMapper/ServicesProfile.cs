using AutoMapper;
using Domain.Dtos;
using Domain.Entites;

namespace Infrastructura.InfrastructuraMapper;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        CreateMap<Chalange, GetChalangeDto>().ReverseMap();
        CreateMap<AddChalangeDto, Chalange>().ReverseMap();
        CreateMap<Group, GetGroupDto>().ReverseMap();
        CreateMap<Group, AddGroupDto>().ReverseMap();
        CreateMap<Location, AddLocationDto>().ReverseMap();
        CreateMap<Participant, AddParticipantDto>().ReverseMap();
    }
}
