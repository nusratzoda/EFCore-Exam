using Domain.Entites;
using Domain.Response;

namespace Infrastructura.Services;

public interface IChalengesServices
{
    Task<Response<Chalange>> AddChalange(Chalange chalange);
    Task<Response<List<Chalange>>> GetChalange();
    Task<Response<Chalange>> UpdateChalange(Chalange chalange);
    Task<Response<string>> DaleteAuthor(int id);

}
