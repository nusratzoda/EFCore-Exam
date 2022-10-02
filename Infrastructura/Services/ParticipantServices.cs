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
    public async Task<Response<Participant>> AddParticipant(Participant participant)
    {
        try
        {
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
            return new Response<Participant>(participant);
        }
        catch (System.Exception ex)
        {

            return new Response<Participant>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<List<Participant>>> GetParticipant()
    {
        try
        {
            var response = await _context.Participants.ToListAsync();
            return new Response<List<Participant>>(response);
        }
        catch (System.Exception ex)
        {

            return new Response<List<Participant>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<Participant>> UpdateParticipant(Participant participant)
    {
        try
        {
            var record = await _context.Participants.FindAsync(participant.Id);
            if (record == null) return new Response<Participant>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Email = participant.Email;
            record.FullName = participant.FullName;
            record.Group = participant.Group;
            record.CreatedAt = participant.CreatedAt;
            record.Location = participant.Location;
            record.LocationId = participant.LocationId;
            record.Phone = participant.Phone;
            record.GroupId = participant.GroupId;
            await _context.SaveChangesAsync();
            return new Response<Participant>(record);
        }
        catch (System.Exception ex)
        {

            return new Response<Participant>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

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
