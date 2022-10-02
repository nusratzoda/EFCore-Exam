using Domain.Entites;
using Domain.Response;

namespace Infrastructura.Services;

public interface IParticipantServices
{
    Task<Response<List<Participant>>> GetParticipant();
    Task<Response<Participant>> UpdateParticipant(Participant participant);
    Task<Response<string>> DaleteParticipant(int id);
    Task<Response<Participant>> AddParticipant(Participant participant);
}
