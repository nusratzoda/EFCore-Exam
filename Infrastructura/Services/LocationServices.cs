using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;
namespace Infrastructura.Services;
public class LocationServices : ILocationServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public LocationServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        var location = await (from lo in _context.Locations
                              select new GetLocationDto()
                              {
                                  Description = lo.Description,
                                  Id = lo.Id,
                                  Name = lo.Name,
                                  Chalanges = (from ch in _context.Chalanges
                                               where ch.LocationId == lo.Id
                                               select _mapper.Map<GetChalangeDto>(ch)
                                               //    select new GetChalangeDto()
                                               //    {
                                               //        Title = ch.Title,
                                               //        Description = ch.Description,
                                               //        Id = ch.Id,
                                               //    }
                                               ).ToList(),

                              }).ToListAsync();
        return new Response<List<GetLocationDto>>(location);
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