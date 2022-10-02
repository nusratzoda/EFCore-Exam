using Domain.Entites;
using Domain.Response;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class LocationControler : ControllerBase
{

    private readonly ILocationServices _locationService;

    public LocationControler(ILocationServices locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("GetLocation")]
    public async Task<Response<List<Location>>> GetLocation()
    {
        return await _locationService.GetLocation();
    }


    [HttpPost("InsertLocation")]
    public async Task<Response<Location>> AddLocation(Location location)
    {
        return await _locationService.AddLocation(location);
    }
    [HttpPut("UpdateLocation")]
    public async Task<Response<Location>> UpdateLocation(Location location)
    {
        return await _locationService.UpdateLocation(location);
    }
    [HttpDelete("DeleteLocation")]
    public async Task<Response<string>> DeleteLocation(int id)
    {
        return await _locationService.DaleteLocation(id);
    }
}





