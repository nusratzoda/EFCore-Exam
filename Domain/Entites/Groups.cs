using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Group
{
    public int Id { get; set; }
    [MaxLength(100)]

    public string GroupsNick { get; set; }
    public int ChallangeId { get; set; }
    [ForeignKey("ChallangeId")]
    public virtual Chalange Challange { get; set; }
    public bool NeededMember { get; set; }
    [MaxLength(300)]

    public string TeamSlogan { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public virtual List<Participant> Participants { get; set; }

    public Group()
    {
        CreatedAt = DateTimeOffset.Now;
    }
}
