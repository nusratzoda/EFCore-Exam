namespace Domain.Entites;

public class Groups
{
    public int Id { get; set; }
    public string? GroupsNick { get; set; }
    public virtual Chalange? Chalange { get; set; }
    public int? ChallangeId { get; set; }
    public bool NeededMember { get; set; }
    public string? TeamSlogan { get; set; }
    public string? CreatedAt { get; set; }
    public virtual List<Participant>? Participants { get; set; }
}
