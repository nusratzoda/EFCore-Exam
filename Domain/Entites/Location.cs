using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Chalange> Chalanges { get; set; }
}
