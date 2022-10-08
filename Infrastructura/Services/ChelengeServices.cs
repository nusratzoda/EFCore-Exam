using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;
namespace Infrastructura.Services;

public class ChelengeServices : IChalengesServices
{


    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ChelengeServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<AddChalangeDto>> AddChalange(AddChalangeDto model)
    {
        try
        {
            var chalange = new Chalange()
            {
                Description = model.Description,
                Title = model.Title
            };
            await _context.Chalanges.AddAsync(chalange);
            await _context.SaveChangesAsync();
            model.Id = chalange.Id;
            return new Response<AddChalangeDto>(model);
        }
        catch (System.Exception ex)
        {

            return new Response<AddChalangeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<List<GetChalangeDto>>> GetChalange()
    {
        var challenge = await (from ch in _context.Chalanges
                               select new GetChalangeDto()
                               {
                                   Description = ch.Description,
                                   Id = ch.Id,
                                   Title = ch.Title,
                                   Groupes = (from g in _context.Groupes
                                              where g.ChallangeId == ch.Id
                                              select _mapper.Map<GetGroupDto>(g)
                                              //   select new GetGroupDto()
                                              //   {
                                              //       ChallangeId = g.ChallangeId,
                                              //       GroupsNick = g.GroupsNick,
                                              //       NeededMember = g.NeededMember,
                                              //       TeamSlogan = g.TeamSlogan,
                                              //       Id = g.Id
                                              //   }
                                              ).ToList(),

                               }).ToListAsync();
        return new Response<List<GetChalangeDto>>(challenge);

    }
    public async Task<Response<AddChalangeDto>> UpdateChalange(AddChalangeDto chalange)
    {
        try
        {
            var record = await _context.Chalanges.FindAsync(chalange.Id);
            if (record == null) return new Response<AddChalangeDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Title = chalange.Title;
            record.Description = chalange.Description;
            await _context.SaveChangesAsync();
            return new Response<AddChalangeDto>(chalange);
        }
        catch (System.Exception ex)
        {

            return new Response<AddChalangeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<GetChalangeDto>> GetChalangeById(int id)
    {
        var result = _mapper.Map<GetChalangeDto>(await _context.Chalanges.FindAsync(id));
        return new Response<GetChalangeDto>(result);
    }
    public async Task<Response<string>> DaleteAuthor(int id)
    {
        try
        {
            var record = await _context.Chalanges.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Chalanges.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
}
