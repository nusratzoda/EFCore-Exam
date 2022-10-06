using Domain.Dtos;
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
    public async Task<Response<AddLocationDto>> AddLocation(AddLocationDto model)
    {
        try
        {
            var location = new Location()
            {
                Description = model.Description,
                Name = model.Name,

            };
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            model.Id = location.Id;
            return new Response<AddLocationDto>(model);
        }
        catch (System.Exception ex)
        {

            return new Response<AddLocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
    public async Task<Response<List<GetLocationDto>>> GetLocation()
    {
        var locations = await _context.Locations.Select(l => new GetLocationDto()
        {
            Description = l.Description,
            Id = l.Id,
            Name = l.Name
        }).ToListAsync();
        return new Response<List<GetLocationDto>>(locations);
    }
    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
    {
        try
        {
            var record = await _context.Locations.FindAsync(location.Id);
            if (record == null) return new Response<AddLocationDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Name = location.Name;
            record.Description = location.Description;
            await _context.SaveChangesAsync();
            return new Response<AddLocationDto>(location);
        }
        catch (System.Exception ex)
        {

            return new Response<AddLocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

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
