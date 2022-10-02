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
    public async Task<Response<Chalange>> AddChalange(Chalange chalange)
    {
        try
        {
            await _context.Chalanges.AddAsync(chalange);
            await _context.SaveChangesAsync();
            return new Response<Chalange>(chalange);
        }
        catch (System.Exception ex)
        {

            return new Response<Chalange>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<List<Chalange>>> GetChalange()
    {
        try
        {
            var response = await _context.Chalanges.ToListAsync();
            return new Response<List<Chalange>>(response);
        }
        catch (System.Exception ex)
        {

            return new Response<List<Chalange>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<Chalange>> UpdateChalange(Chalange chalange)
    {
        try
        {
            var record = await _context.Chalanges.FindAsync(chalange.Id);
            if (record == null) return new Response<Chalange>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Title = chalange.Title;
            record.Description = chalange.Description;
            await _context.SaveChangesAsync();
            return new Response<Chalange>(record);
        }
        catch (System.Exception ex)
        {

            return new Response<Chalange>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
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
