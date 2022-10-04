using Domain.Dtos;
using Domain.Response;
using Domain.Entites;
namespace Infrastructura.Services;

public interface ILocationServices
{
    Task<Response<AddLocationDto>> AddLocation(AddLocationDto location);
    Task<Response<List<GetLocationDto>>> GetLocation();
    Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location);
    Task<Response<string>> DaleteLocation(int id);
}
