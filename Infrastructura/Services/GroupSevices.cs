using Domain.Dtos;
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
    public async Task<Response<AddGroupDto>> AddGroups(AddGroupDto model)
    {
        try
        {
            var group = new Groups()
            {
                TeamSlogan = model.TeamSlogan,
                NeededMember = model.NeededMember,
                CreatedAt = model.CreatedAt,
                GroupsNick = model.GroupsNick,
                ChallangeId = model.ChallangeId
            };
            await _context.Groupes.AddAsync(group);
            await _context.SaveChangesAsync();
            return new Response<AddGroupDto>(model);
        }

        catch (Exception ex)
        {

            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {

        var group = await _context.Groupes.Select(G => new GetGroupDto()
        {
            TeamSlogan = G.TeamSlogan,
            Id = G.Id,
            NeededMember = G.NeededMember,
            GroupsNick = G.GroupsNick,
            CreatedAt = G.CreatedAt,
            ChallangeId = G.ChallangeId
        }).ToListAsync();
        var response = await _context.Groupes.ToListAsync();
        return new Response<List<GetGroupDto>>(group);


    }
    public async Task<Response<AddGroupDto>> UpdateGroups(AddGroupDto groups)
    {
        try
        {
            var record = await _context.Groupes.FindAsync(groups.Id);
            if (record == null) return new Response<AddGroupDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.TeamSlogan = groups.TeamSlogan;
            record.NeededMember = groups.NeededMember;
            record.CreatedAt = groups.CreatedAt;
            record.GroupsNick = groups.GroupsNick;
            record.ChallangeId = groups.ChallangeId;
            await _context.SaveChangesAsync();
            return new Response<AddGroupDto>(groups);
        }
        catch (System.Exception ex)
        {
            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
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
