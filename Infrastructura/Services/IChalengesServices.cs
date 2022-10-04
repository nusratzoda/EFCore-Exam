using Domain.Entites;
using Domain.Response;
using Domain.Dtos;
namespace Infrastructura.Services;

public interface IChalengesServices
{
    Task<Response<AddChalangeDto>> AddChalange(AddChalangeDto chalange);
    Task<Response<List<GetChalangeDto>>> GetChalange();
    Task<Response<AddChalangeDto>> UpdateChalange(AddChalangeDto chalange);
    Task<Response<string>> DaleteAuthor(int id);

}
