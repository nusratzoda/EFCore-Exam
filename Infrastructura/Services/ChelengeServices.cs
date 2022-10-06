using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;
namespace Infrastructura.Services;

public class ChelengeServices : IChalengesServices
{


    private readonly DataContext _context;
    public ChelengeServices(DataContext context)
    {
        _context = context;
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
        var locations = await _context.Chalanges.Select(C => new GetChalangeDto()
        {
            Description = C.Description,
            Id = C.Id,
            Title = C.Title
        }).ToListAsync();
        return new Response<List<GetChalangeDto>>(locations);

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
