using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Groups
{
    public int Id { get; set; }
    public string GroupsNick { get; set; }
    public int ChallangeId { get; set; }
    [ForeignKey("ChallangeId")]
    public virtual Chalange Challange { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public virtual List<Participant> Participants { get; set; }
}
