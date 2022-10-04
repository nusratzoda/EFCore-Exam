using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddGroupDto
{
    public int Id { get; set; }
    [Required, MaxLength(200)]

    public string GroupsNick { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ChallangeId { get; set; }
}
