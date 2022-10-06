namespace Domain.Dtos;

public class GetGroupDto
{
    public int Id { get; set; }
    public string GroupsNick { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int ChallangeId { get; set; }
    public string ChallangeName { get; set; }

}
