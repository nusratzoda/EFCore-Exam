using Domain.Entites;
using Domain.Response;
using Domain.Dtos;
namespace Infrastructura.Services;

public interface IParticipantServices
{
    Task<Response<List<GetParticipantDto>>> GetParticipant();
    Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto participant);
    Task<Response<string>> DaleteParticipant(int id);
    Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto participant);
}
