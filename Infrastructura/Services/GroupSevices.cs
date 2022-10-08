using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Services;

public class GroupSevices : IGroupServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public GroupSevices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<AddGroupDto>> AddGroups(AddGroupDto model)
    {
        try
        {

            Group mapped = _mapper.Map<Group>(model);


            await _context.Groupes.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id = mapped.Id;
            return new Response<AddGroupDto>(_mapper.Map<AddGroupDto>(mapped));
        }

        catch (Exception ex)
        {

            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {

        var group = await (from gr in _context.Groupes
                           join ch in _context.Chalanges
                            on gr.ChallangeId equals ch.Id
                           select new GetGroupDto()
                           {
                               NeededMember = gr.NeededMember,
                               Id = gr.Id,
                               GroupsNick = gr.GroupsNick,
                               TeamSlogan = gr.TeamSlogan,
                               CreatedAt = gr.CreatedAt,
                               ChallangeId = ch.Id,
                               ChallangeName = ch.Title,
                               Participants = (from pr in _context.Participants
                                               where gr.Id == pr.GroupId
                                               join lo in _context.Locations
                                               on pr.LocationId equals lo.Id
                                               select new GetParticipantDto()
                                               {
                                                   CreatedAt = pr.CreatedAt,
                                                   Email = pr.Email,
                                                   FullName = pr.FullName,
                                                   Phone = pr.Phone,
                                                   Id = pr.Id,
                                                   LocationId = pr.LocationId,
                                                   GroupId = pr.GroupId,
                                                   GroupName = gr.GroupsNick,
                                                   LocationName = lo.Name,
                                               }).ToList(),

                           }).ToListAsync();
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
