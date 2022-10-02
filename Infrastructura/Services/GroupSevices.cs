using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Services;

public class GroupSevices : IGroupServices
{
    private readonly DataContext _context;
    public GroupSevices(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<Groups>> AddGroups(Groups groups)
    {
        try
        {
            await _context.Groupes.AddAsync(groups);
            await _context.SaveChangesAsync();
            return new Response<Groups>(groups);
        }

        catch (Exception ex)
        {

            return new Response<Groups>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<List<Groups>>> GetGroups()
    {
        try
        {
            var response = await _context.Groupes.ToListAsync();
            return new Response<List<Groups>>(response);
        }
        catch (Exception ex)
        {

            return new Response<List<Groups>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<Groups>> UpdateGroups(Groups groups)
    {
        try
        {
            var record = await _context.Groupes.FindAsync(groups.Id);
            if (record == null) return new Response<Groups>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.TeamSlogan = groups.TeamSlogan;
            record.NeededMember = groups.NeededMember;
            record.Participants = groups.Participants;
            record.CreatedAt = groups.CreatedAt;
            record.GroupsNick = groups.GroupsNick;
            record.ChallangeId = groups.ChallangeId;
            record.Chalange = groups.Chalange;
            await _context.SaveChangesAsync();
            return new Response<Groups>(record);
        }
        catch (System.Exception ex)
        {
            return new Response<Groups>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }

    public async Task<Response<string>> DaleteGroups(int id)
    {
        try
        {
            var record = await _context.Groupes.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Groupes.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
}
