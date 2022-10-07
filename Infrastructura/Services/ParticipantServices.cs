using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;
namespace Infrastructura.Services;
public class ParticipantServices : IParticipantServices
{
    private readonly DataContext _context;
    public ParticipantServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto model)
    {
        try
        {
            var participant = new Participant()
            {
                Email = model.Email,
                FullName = model.FullName,
                CreatedAt = model.CreatedAt,
                Phone = model.Phone,
                LocationId = model.LocationId,
                GroupId = model.GroupId
            };
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
            model.Id = participant.Id;
            return new Response<AddParticipantDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<List<GetParticipantDto>>> GetParticipant()
    {
        var participant = await (from pr in _context.Participants
                                 join gr in _context.Groupes
                                 on pr.GroupId equals gr.Id
                                 join lc in _context.Locations
                                 on pr.LocationId equals lc.Id
                                 orderby gr.CreatedAt descending
                                 select new GetParticipantDto
                                 {
                                     Email = pr.Email,
                                     Id = pr.Id,
                                     FullName = pr.FullName,
                                     Phone = pr.Phone,
                                     CreatedAt = pr.CreatedAt,
                                     LocationName = lc.Name,
                                     GroupName = gr.GroupsNick
                                 }).ToListAsync();
        return new Response<List<GetParticipantDto>>(participant);
    }
    public async Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto participant)
    {
        try
        {
            var record = await _context.Participants.FindAsync(participant.Id);
            if (record == null) return new Response<AddParticipantDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Email = participant.Email;
            record.FullName = participant.FullName;
            record.CreatedAt = participant.CreatedAt;
            record.Phone = participant.Phone;
            record.LocationId = participant.LocationId;
            record.GroupId = participant.GroupId;
            await _context.SaveChangesAsync();
            return new Response<AddParticipantDto>(participant);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DaleteParticipant(int id)
    {
        try
        {
            var record = await _context.Participants.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Participants.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}