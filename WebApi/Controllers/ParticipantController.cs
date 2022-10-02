using Domain.Entites;
using Domain.Response;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ParticipantController
{
    private readonly IParticipantServices _participantService;

    public ParticipantController(IParticipantServices participantService)
    {
        _participantService = participantService;
    }

    [HttpGet("GetParticipant")]
    public async Task<Response<List<Participant>>> GetParticipant()
    {
        return await _participantService.GetParticipant();
    }


    [HttpPost("InsertParticipant")]
    public async Task<Response<Participant>> AddParticipant(Participant participant)
    {
        return await _participantService.AddParticipant(participant);
    }
    [HttpPut("UpdateParticipant")]
    public async Task<Response<Participant>> UpdateParticipant(Participant participant)
    {
        return await _participantService.UpdateParticipant(participant);
    }
    [HttpDelete("DeleteParticipant")]
    public async Task<Response<string>> DeleteParticipant(int id)
    {
        return await _participantService.DaleteParticipant(id);
    }
}
