using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;
namespace Infrastructura.Services;

public class LocationServices : ILocationServices
{
    private readonly DataContext _context;
    public LocationServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<Location>> AddLocation(Location location)
    {
        try
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return new Response<Location>(location);
        }
        catch (System.Exception ex)
        {

            return new Response<Location>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<List<Location>>> GetLocation()
    {
        try
        {
            var response = await _context.Locations.ToListAsync();
            return new Response<List<Location>>(response);
        }
        catch (System.Exception ex)
        {

            return new Response<List<Location>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<Location>> UpdateLocation(Location location)
    {
        try
        {
            var record = await _context.Locations.FindAsync(location.Id);
            if (record == null) return new Response<Location>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Name = location.Name;
            record.Description = location.Description;
            await _context.SaveChangesAsync();
            return new Response<Location>(record);
        }
        catch (System.Exception ex)
        {

            return new Response<Location>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }

    public async Task<Response<string>> DaleteLocation(int id)
    {
        try
        {
            var record = await _context.Locations.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Locations.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
}
