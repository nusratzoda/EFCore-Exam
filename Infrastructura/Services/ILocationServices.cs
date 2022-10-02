using Domain.Entites;
using Domain.Response;

namespace Infrastructura.Services;

public interface ILocationServices
{
    Task<Response<Location>> AddLocation(Location location);
    Task<Response<List<Location>>> GetLocation();
    Task<Response<Location>> UpdateLocation(Location location);
    Task<Response<string>> DaleteLocation(int id);
}
