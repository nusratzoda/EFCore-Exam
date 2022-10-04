using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class GroupControler : ControllerBase
{
    private readonly IGroupServices _groupService;

    public GroupControler(IGroupServices groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("GetGroup")]
    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        return await _groupService.GetGroups();
    }


    [HttpPost("InsertGroup")]
    public async Task<Response<AddGroupDto>> AddGroups(AddGroupDto groups)
    {
        return await _groupService.AddGroups(groups);
    }
    [HttpPut("UpdateGroup")]
    public async Task<Response<AddGroupDto>> UpdateGroups(AddGroupDto groups)
    {
        return await _groupService.UpdateGroups(groups);
    }
    [HttpDelete("DeleteGroup")]
    public async Task<Response<string>> DeleteGroup(int id)
    {
        return await _groupService.DaleteGroups(id);
    }
}
