using System.Text.RegularExpressions;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Cantext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Domain.Entites.Group> Groupes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Chalange> Chalanges { get; set; }
}
