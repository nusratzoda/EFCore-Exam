using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class Chalange
{

    public int Id { get; set; }
    [Required, MaxLength(200)]

    public string Title { get; set; }
    public string Description { get; set; }
    public int LocationId { get; set; }
    public virtual List<Group> Groups { get; set; }

}
