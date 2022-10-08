using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddGroupDto
{
    public int Id { get; set; }
    [Required, MaxLength(200)]

    public string GroupsNick { get; set; }
    public bool NeededMember { get; set; }
    [MaxLength(300)]

    public string TeamSlogan { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int ChallangeId { get; set; }

    public AddGroupDto()
    {
        CreatedAt = DateTimeOffset.Now;
    }
}
