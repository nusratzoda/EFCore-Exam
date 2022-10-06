using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddParticipantDto
{
    public int Id { get; set; }
    [Required, MaxLength(100)]

    public string FullName { get; set; }
    [Required, MaxLength(90)]
    public string Email { get; set; }
    [Required, MaxLength(60)]
    public string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int LocationId { get; set; }
    public int GroupId { get; set; }
}
