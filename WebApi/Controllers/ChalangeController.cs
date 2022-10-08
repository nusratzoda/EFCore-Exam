using AutoMapper;
using Domain.Dtos;
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

    [HttpGet]
    public async Task<Response<List<GetChalangeDto>>> GetChalange()
    {
        return await _cahlengeService.GetChalange();
    }


    [HttpGet("GetChallengeById")]
    public async Task<Response<GetChalangeDto>> GetChalangeById(int id)
    {
        return await _cahlengeService.GetChalangeById(id);
    }

    [HttpPost]
    public async Task<Response<AddChalangeDto>> AddChalange(AddChalangeDto chalange)
    {
        return await _cahlengeService.AddChalange(chalange);
    }
    [HttpPut]
    public async Task<Response<AddChalangeDto>> UpdateChalange(AddChalangeDto chalange)
    {
        return await _cahlengeService.UpdateChalange(chalange);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteChalange(int id)
    {
        return await _cahlengeService.DaleteAuthor(id);
    }
}
