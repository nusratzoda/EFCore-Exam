using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Participant
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int GroupId { get; set; }
    [ForeignKey("GroupId")]
    public virtual Groups Group { get; set; }
    public int LocationId { get; set; }
    [ForeignKey("LocationId")]
    public virtual Location Location { get; set; }
}
