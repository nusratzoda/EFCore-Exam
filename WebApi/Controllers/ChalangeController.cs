using Domain.Entites;
using Domain.Response;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ChalangeController : ControllerBase
{
    private readonly IChalengesServices _cahlengeService;

    public ChalangeController(IChalengesServices cahlengeService)
    {
        _cahlengeService = cahlengeService;
    }

    [HttpGet("GetChalange")]
    public async Task<Response<List<Chalange>>> GetChalange()
    {
        return await _cahlengeService.GetChalange();
    }


    [HttpPost("InsertAuthor")]
    public async Task<Response<Chalange>> AddChalange(Chalange chalange)
    {
        return await _cahlengeService.AddChalange(chalange);
    }
    [HttpPut("UpdateChalange")]
    public async Task<Response<Chalange>> UpdateChalange(Chalange chalange)
    {
        return await _cahlengeService.UpdateChalange(chalange);
    }
    [HttpDelete("DeleteChalange")]
    public async Task<Response<string>> DeleteChalange(int id)
    {
        return await _cahlengeService.DaleteAuthor(id);
    }
}
