using Domain.Entites;
using Domain.Response;
using Domain.Dtos;
namespace Infrastructura.Services;

public interface IGroupServices
{
    Task<Response<AddGroupDto>> AddGroups(AddGroupDto groups);
    Task<Response<List<GetGroupDto>>> GetGroups();
    Task<Response<AddGroupDto>> UpdateGroups(AddGroupDto groups);
    Task<Response<string>> DaleteGroups(int id);
}
