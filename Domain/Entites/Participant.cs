using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Participant
{
    public int Id { get; set; }
    [Required, MaxLength(60)]

    public string FullName { get; set; }
    [EmailAddress]

    public string Email { get; set; }
    [Required, MaxLength(13)]

    public string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int GroupId { get; set; }
    [ForeignKey("GroupId")]
    public virtual Group Group { get; set; }
    public int LocationId { get; set; }
    [ForeignKey("LocationId")]
    public virtual Location Location { get; set; }
    public Participant()
    {
        CreatedAt = DateTimeOffset.Now;
    }

}
