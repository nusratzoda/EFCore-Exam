using Domain.Entites;
using Domain.Response;

namespace Infrastructura.Services;

public interface IGroupServices
{
    Task<Response<Groups>> AddGroups(Groups groups);
    Task<Response<List<Groups>>> GetGroups();
    Task<Response<Groups>> UpdateGroups(Groups groups);
    Task<Response<string>> DaleteGroups(int id);
}
