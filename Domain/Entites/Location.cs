using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Location
{
    public int Id { get; set; }
    [Required, MaxLength(200)]
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Participant> Participants { get; set; }
}
